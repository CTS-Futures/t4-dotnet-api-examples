using T4.API;
using T4;
using System.Diagnostics;

Trace.AutoFlush = true;
Trace.IndentSize = 2;
var t4Trace = new T4.TraceListener.T4TraceListener();
Trace.Listeners.Add(t4Trace);

Host moHost;

//  Reference to the current account.
Account moAccount = null;

// Reference to the current exchange.
Exchange moExchange;

// Reference to the current contract.
Contract moContract;

// Reference to the current market.
Market moPickerMarket = null;

// References to selected markets.
Market moMarket1 = null;
Market moMarket2 = null;

// References to marketid's retrieved from saved settings.
string mstrMarketID1;
string mstrMarketID2;

//Trace.Listeners.Add(new TextWriterTraceListener("CTSlog.txt"));
//TODO: Add app.config, verify the trace is being stored in the right location defined in the config.

// Event that is raised when details for an account have 
// changed, or a new account is recieved.
void moAccounts_AccountDetails(AccountDetailsEventArgs e)
{
    Console.WriteLine(e.Account.AccountID);
}


moHost = new Host(APIServerType.Simulator, "T4Example", "112A04B0-5AAF-42F4-994E-FA7CB959C60B", "CTSDEV", "danforero03", "Temp123$");
moHost.Accounts.AccountDetails += new T4.API.AccountList.AccountDetailsEventHandler(moAccounts_AccountDetails);

await Task.Delay(2000); //Give it time to load the messages

while (true)
{
    if (moAccount == null && moPickerMarket == null)
    {
        Console.WriteLine("\nMAIN MENU:\n");
        Console.WriteLine("Press 1 to print the accounts for the user");
        Console.WriteLine("Press 2 to print the exchange list for the user");
        Console.WriteLine("Press any other key to exit");

        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                PrintAccountList();
                break;
            case "2":
                PintExchangeList();
                break;
            default:
                Environment.Exit(42);
                return;
        }
    }
}


void PrintAccountList()
{
    try
    {
        Console.Clear();
        // Lock the API.
        moHost.EnterLock();

        // Display the account list.
        Console.WriteLine("ACCOUNT INFORMATION:\n");
        int i = 0;
        var accountIds = new List<string>();
        foreach (Account oAccount in moHost.Accounts)
        {
            accountIds.Add(oAccount.AccountID);
            Console.WriteLine($"Account Index: {i}");
            Console.WriteLine($"Account Id: {oAccount.AccountID}");
            Console.WriteLine($"Account Name: {oAccount.AccountNumber}");
            //Console.WriteLine($"Available Cash: {String.Format("{0:#,###,##0.00}", oAccount.AvailableCash)}");
            Console.WriteLine("\n");
            i++;
        }

        Console.WriteLine("Enter the index of the acccount you want to select");
        var strAccountSelected = Console.ReadLine();
        var accountIndex = int.Parse(strAccountSelected);
        var selectedAccount = accountIds[accountIndex];
        PrintAccountInformation(selectedAccount);
    }
    catch (Exception ex)
    {
        // Trace Errors.
        Trace.WriteLine(ex.ToString());
    }
    finally
    {
        // Unlock the api.
        moHost.ExitLock();
    }
}


void PintExchangeList()
{
    try
    {
        Console.Clear();
        // Lock the API.
        moHost.EnterLock();
        Console.WriteLine("EXCHANGE LIST:");
        int i = 0;
        var exchangeIds = new List<string>();
        foreach (var exchange in moHost.MasterUser.Exchanges)
        {
            exchangeIds.Add(exchange.Exchange.ExchangeID);
            Console.WriteLine($"Exchange Index: {i}");
            Console.WriteLine($"{exchange.Exchange.Description}");
            i++;
        }

        var strExchangeSelected = Console.ReadLine();
        var exchangeIndex = int.Parse(strExchangeSelected);
        var selectedExchange = exchangeIds[exchangeIndex];
        moExchange = moHost.MasterUser.Exchanges.SingleOrDefault(e => e.ExchangeID == selectedExchange).Exchange;
        PrintContracts(selectedExchange);
    }
    catch (Exception ex)
    {
        // Trace Errors.
        Trace.WriteLine(ex.ToString());
    }
    finally
    {
        // Unlock the api.
        moHost.ExitLock();
    }
}

void PrintContracts(string selectedExchange)
{
    Console.Clear();
    // Eliminate any previous references.
    moContract = null;
    moPickerMarket = null;

    if (moExchange != null)
    {
        Console.WriteLine("CONTRACT LIST:");
        try
        {
            int i = 0;
            var contractIds = new List<string>();
            // Add the exchanges to the dropdown list.
            foreach (Contract oContract in moExchange.Contracts)
            {
                contractIds.Add(oContract.ContractID);
                Console.WriteLine($"Contract Index: {i}");
                Console.WriteLine(oContract.Description);
                i++;
            }
            var strContractSelected = Console.ReadLine();
            var contractIndex = int.Parse(strContractSelected);
            var selectedContract = contractIds[contractIndex];
            moContract = moExchange.Contracts.SingleOrDefault(c => c.ContractID == selectedContract);
            PrintMarkets(selectedContract);
        }
        catch (Exception ex)
        {
            // Trace the error.
            Trace.WriteLine("Error " + ex.ToString());
        }
    }
}

void PrintMarkets(string selectedContract)
{

    moContract.GetMarkets(0, StrategyType.None, e2 =>
    {
        DisplayMarkets(e2);
    });
}

void DisplayMarkets(MarketListEventArgs e)
{
    Console.Clear();
    // Populate the list of markets available for the current contract.
    // Eliminate any previous references.
    moPickerMarket = null;

    try
    {
        int i = 0;
        var marketIds = new List<string>();
        // Add the markets to the dropdown list.
        foreach (Market oMarket in e.Markets.GetSortedList())
        {
            marketIds.Add(oMarket.MarketID);
            Console.WriteLine($"Market Index: {i}");
            Console.WriteLine(oMarket.Description);
            i++;
        }
        var strMarketSelected = Console.ReadLine();
        var marketIndex = int.Parse(strMarketSelected);
        var selectedMarket = marketIds[marketIndex];
        moPickerMarket = e.Markets.SingleOrDefault(m => m.MarketID == selectedMarket);
    }
    catch (Exception ex)
    {
        // Trace the error.
        Trace.WriteLine("Error " + ex.ToString());
    }
}

void PrintAccountInformation(string selectedAccount)
{
    moAccount = moHost.Accounts[selectedAccount];

    // Register the account's events.
    if (moAccount != null)
    {
        OnAccountDetails(new AccountDetailsEventArgs(moAccount));
        moAccount.OrderUpdate += new T4.API.Account.OrderUpdateEventHandler(moAccount_OrderUpdate);
        moAccount.PositionUpdate += new T4.API.Account.PositionUpdateEventHandler(moAccounts_PositionUpdate);
        moAccount.AccountUpdate += new T4.API.Account.AccountUpdateEventHandler(moAccounts_AccountUpdate);


        Console.WriteLine("Loading Account Information ...");
        //// Display the current account balance.
        //DisplayAccount();

        //// Refresh positions.
        //DisplayPosition(moMarket1, 1);
        //
        //DisplayPosition(moMarket2, 2);        
    }
}

void moAccount_OrderUpdate(OrderUpdateEventArgs e)
{
    DisplayOrders();
}

void DisplayOrders()
{
    Console.WriteLine("ORDERS:\n");
    try
    {
        // Lock the api.
        moHost.EnterLock();

        // Itterate through the orders, newest is first.
        foreach (Order oOrder in moAccount.Orders.GetSortedList())
        {
            Console.WriteLine($"{oOrder.Market.Description} {oOrder.BuySell} {oOrder.TotalFillVolume}/{oOrder.CurrentVolume} @ {oOrder.Market.PriceToDisplay(oOrder.CurrentLimitPrice)} {oOrder.Status.ToString()} {oOrder.StatusDetail} {oOrder.SubmitTime}");
        }
    }
    catch (Exception ex)
    {
        // Trace the error.
        Trace.WriteLine("Error: " + ex.ToString());
    }
    finally
    {
        // Unlock the api.
        moHost.ExitLock();
    }
}

//' Event that is raised when positions for accounts have changed.
void moAccounts_PositionUpdate(PositionUpdateEventArgs e)
{
    // Display the position details.
    // If the position is for the current account
    // then update the value.
    if (e.Account == moAccount)
    {
        OnPositionUpdate(e);
    }
}

void OnPositionUpdate(PositionUpdateEventArgs e)
{
    // Display the position details.
    if (e.Position.Market == moMarket1)
        DisplayPosition(e.Position.Market, 1);
    else if (e.Position.Market == moMarket2)
        DisplayPosition(e.Position.Market, 2);
}

// Event that is raised when the accounts overall balance,
// P&L or margin details have changed.
void moAccounts_AccountUpdate(AccountUpdateEventArgs e)
{
    // Invoke the update.
    // This places process on GUI thread.
    DisplayAccount();
}

void DisplayAccounts()
{

    try
    {
        // Lock the API.
        moHost.EnterLock();

        // Display the account list.

        foreach (Account oAccount in moHost.Accounts)
        {
            OnAccountDetails(new AccountDetailsEventArgs(oAccount));
        }

        //if (cboAccounts.Items.Count > 0)
        //{
        //    cboAccounts.SelectedIndex = 0;
        //}

    }
    catch (Exception ex)
    {
        // Trace Errors.
        Trace.WriteLine(ex.ToString());
    }
    finally
    {
        // Unlock the api.
        moHost.ExitLock();
    }

}

void OnAccountDetails(AccountDetailsEventArgs e)
{
    // Check to see if the account exists prior to adding/subscribing to it.
    if (e.Account.Subscribed != true)
    {

        //// Add the account to the list.
        //cboAccounts.Items.Add(e.Account);

        // Subscribe to the account.
        e.Account.Subscribe(e2 =>
        {
            moAccounts_AccountComplete(e2);
        });

    }
}
void moAccounts_AccountComplete(AccountCompleteEventArgs e)
{
    DisplayAccount();

    // Refresh positions.
    DisplayPosition(moMarket1, 1);
    DisplayPosition(moMarket2, 2);

    DisplayOrders();
}

void DisplayAccount()
{
    Console.Clear();
    Console.WriteLine("ACCOUNT INFORMATION:\n");
    if ((moAccount != null))
    {
        try
        {
            Console.WriteLine($"Available cash: {String.Format("{0:#,###,##0.00}", moAccount.AvailableCash)}");
        }
        catch (Exception ex)
        {
            // Trace the error.
            Trace.WriteLine("Error: " + ex.ToString());

        }
        Console.WriteLine();
        DisplayOrders();
    }
}

void DisplayPosition(Market poMarket, int piID)
{
    string strNet = "";
    string strBuys = "";
    string strSells = "";

    try
    {

        if ((poMarket != null) && (moAccount != null))
        {

            // Display positions for current account and market1.

            // Reference the market's positions.
            Position oPosition = moAccount.Positions[poMarket.MarketID];

            if ((oPosition != null))
            {
                // Reference the net position.
                strNet = oPosition.Net.ToString();
                strBuys = oPosition.Buys.ToString();
                strSells = oPosition.Sells.ToString();
                Console.WriteLine($"Net: {strNet} Buys: {strBuys} Sells: {strSells}");
            }

            //switch (piID)
            //{
            //    case 1:

            //        // Display the total Buys.
            //        txtBuys1.Text = strBuys;
            //        // Display the total Sells.
            //        txtSells1.Text = strSells;

            //        break;
            //    case 2:

            //        // Display the net position.
            //        txtNet2.Text = strNet;
            //        // Display the total Buys.
            //        txtBuys2.Text = strBuys;
            //        // Display the total Sells.
            //        txtSells2.Text = strSells;

            //        break;
            //}

        }

    }
    catch (Exception ex)
    {
        // Trace the error.
        Trace.WriteLine("Error " + ex.ToString());

    }
}