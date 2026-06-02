using System;
using System.Linq;
using System.Threading;
using T4;
using T4.API;


namespace T4ContractQuoteFeed
{
    /// <summary>
    /// Console example that subscribes to the Contract Quote Feed for a single contract.
    /// Reference: https://wiki.t4login.com/api47help/html/0730f740-c313-4958-b5b9-0eba1ac899f1.htm
    ///
    /// The contract quote feed delivers a consolidated quote (Bid/Ask/Last/Volume/Mode)
    /// for an entire contract. Subscribe via Contract.QuoteSubscribe() and listen to the
    /// Contract.ContractQuoteUpdate event.
    /// </summary>
    internal class Program
    {
        private static Host? moHost;
        private static Contract? moContract;
        private static readonly ManualResetEventSlim _exit = new ManualResetEventSlim(false);

        private static void Main()
        {
            Console.WriteLine("T4 Contract Quote Feed example");
            Console.WriteLine("------------------------------");

            // Prompt for credentials (same approach as T4ExampleLinuxCs).
            Console.Write("Firm: ");
            var firm = Console.ReadLine();
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            try
            {
                moHost = new Host(
                    APIServerType.Simulator,
                    "T4Example",
                    "112A04B0-5AAF-42F4-994E-FA7CB959C60B",
                    firm,
                    username,
                    password);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login failed: " + ex.Message);
                return;
            }

            Console.WriteLine("Login success.  Loading exchanges...");
            // Give the API time to receive the initial market data definitions.
            Thread.Sleep(20000);

            try
            {
                if (!TryPickContract(out moContract) || moContract == null)
                {
                    Console.WriteLine("No contract selected.");
                    return;
                }

                // Hook the quote feed event BEFORE subscribing.
                moContract.ContractFeed += Contract_ContractFeed;

                Console.WriteLine($"Subscribing to contract quote for: {moContract.Description}");
                moContract.Subscribe(true,false);

                Console.WriteLine();
                Console.WriteLine("Streaming quotes.  Press <Enter> to exit.");
                Console.WriteLine();

                Console.CancelKeyPress += (s, e) => { e.Cancel = true; _exit.Set(); };

                // Wait for either Enter or Ctrl+C.
                var readThread = new Thread(() => { Console.ReadLine(); _exit.Set(); })
                {
                    IsBackground = true
                };
                readThread.Start();
                _exit.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                Shutdown();
            }
        }

        private static bool TryPickContract(out Contract? contract)
        {
            contract = null;
            if (moHost == null) return false;

            // List exchanges available to the user.
            var exchanges = moHost.MasterUser.Exchanges.ToList();
            if (exchanges.Count == 0)
            {
                Console.WriteLine("No exchanges available for this user.");
                return false;
            }

            Console.WriteLine();
            Console.WriteLine("Available exchanges:");
            for (int i = 0; i < exchanges.Count; i++)
            {
                Console.WriteLine($"  {i}. {exchanges[i].Exchange.Description}");
            }
            Console.Write("Select exchange index: ");
            if (!int.TryParse(Console.ReadLine(), out int exIdx) || exIdx < 0 || exIdx >= exchanges.Count)
                return false;

            Exchange exchange = exchanges[exIdx].Exchange;

            // List contracts on the exchange.
            var contracts = exchange.Contracts.ToList();
            if (contracts.Count == 0)
            {
                Console.WriteLine("No contracts available for this exchange.");
                return false;
            }

            Console.WriteLine();
            Console.WriteLine($"Contracts on {exchange.Description}:");
            for (int i = 0; i < contracts.Count; i++)
            {
                Console.WriteLine($"  {i}. {contracts[i].Description}");
            }
            Console.Write("Select contract index: ");
            if (!int.TryParse(Console.ReadLine(), out int cIdx) || cIdx < 0 || cIdx >= contracts.Count)
                return false;

            contract = contracts[cIdx];
            return true;
        }

        private static void Contract_ContractFeed(ContractFeedEventArgs e)
        {
            // The contract and its current market mode
            var contract = e.Contract;
            var mode = e.Mode;

            // Process each item in the update
            foreach (var item in e.Items)
            {
                if (item is ContractFeedEventArgs.Quote q)
                {
                    // Access q.BidPrice, q.BidVolume, q.OfferPrice, q.OfferVolume
                    // q.BidRealPrice/BidRealVolume exclude implied prices
                    Console.WriteLine(
                        "[{0:HH:mm:ss.fff}] {1}  Mode={2}  Bid {3}x{4}  Offer {5}x{6}",
                        DateTime.Now, q.MarketID, mode,
                        q.BidPrice, q.BidVolume, q.OfferPrice, q.OfferVolume);                    
                }
                else if (item is ContractFeedEventArgs.Trade t)
                {
                    // Access t.LastTradePrice, t.LastTradeVolume, t.TotalTradedVolume
                    // t.AtBidOrOffer, t.DueToSpread
                    Console.WriteLine(
                        "[{0:HH:mm:ss.fff}] {1}  TRADE  Last {2}x{3}  TotalVol {4}  AtBidOrOffer={5}  DueToSpread={6}",
                        DateTime.Now, t.MarketID,
                        t.LastTradePrice, t.LastTradeVolume, t.TotalTradedVolume,
                        t.AtBidOrOffer, t.DueToSpread);
                }
                else if (item is ContractFeedEventArgs.Settlement s)
                {
                    // Access s.Price, s.TradeDate
                    Console.WriteLine(
                        "[{0:HH:mm:ss.fff}] {1}  SETTLEMENT  Price={2}  TradeDate={3}",
                        DateTime.Now, s.MarketID, s.Price, s.TradeDate);
                }
                else if (item is ContractFeedEventArgs.OpenInterest oi)
                {
                    // Access oi.OpenInterest, oi.TradeDate
                    Console.WriteLine(
                        "[{0:HH:mm:ss.fff}] {1}  OPEN INTEREST  OI={2}  TradeDate={3}",
                        DateTime.Now, oi.MarketID, oi.OpenInterest, oi.TradeDate);
                }
            }
        }



        private static void Shutdown()
        {
            try
            {
                if (moContract != null)
                {
                    moContract.ContractFeed -= Contract_ContractFeed;
                    moContract.Subscribe(false,false);
                    moContract = null;
                }
            }
            catch { /* best effort */ }

            try
            {
                if (moHost != null)
                {
                    moHost.Dispose();
                    moHost = null;
                }
            }
            catch { /* best effort */ }
        }
    }
}
