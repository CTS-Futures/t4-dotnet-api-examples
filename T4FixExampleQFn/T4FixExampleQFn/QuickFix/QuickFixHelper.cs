using System;
using System.IO;
using System.Text;

namespace T4FixExampleQFn.QuickFix
{

public static class QuickFixHelper
    {
        public static void WriteStunnelInitiator(string directoryPath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentException("directoryPath is required", nameof(directoryPath));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("fileName is required", nameof(fileName));

            // Ensure directory exists
            Directory.CreateDirectory(directoryPath);

            string fullPath = Path.Combine(directoryPath, fileName);

            string content = """
                [DEFAULT]
                ConnectionType=initiator
                SocketConnectHost=fix-sim.t4login.com
                SocketConnectPort=10443
                SSLValidateCertificates=N
                SSLCheckCertificateRevocation=N
                UseSSL=Y
                SSLEnable=Y
                SSLProtocols=Tls12
                HeartBtInt=30
                ReconnectInterval=100
                FileStorePath=..\..\..\..\Trace\logs\
                FileLogPath=..\..\..\..\Trace\store\

                [SESSION]
                BeginString=FIX.4.2
                SenderCompID=T4Example
                TargetCompID=CTS
                StartTime=00:00:00
                EndTime=23:59:59
                ResetOnLogon=Y
                UseDataDictionary=Y
                DataDictionary=QuickFix\FIX42.xml
                MarketDataRequest=Y
                SecurityDefinitionRequest=Y

                [LOG]
                UseScreenLog=Y
                EventLogging=Y
                ScreenLogLevel=5
                ScreenLogShowIncoming=Y
                ScreenLogShowOutgoing=Y

                [VALIDATION]
                ValidateFieldsOutOfOrder=N
                ValidateUserDefinedFields=N
                AllowUnknownMsgFields=Y
                """;

            File.WriteAllText(fullPath, content, Encoding.UTF8);
        }

        public static void WriteSSLSocketInitiator(string directoryPath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentException("directoryPath is required", nameof(directoryPath));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("fileName is required", nameof(fileName));

            Directory.CreateDirectory(directoryPath);

            string fullPath = Path.Combine(directoryPath, fileName);

            string content = """
                [DEFAULT]
                ConnectionType=initiator
                SocketConnectHost=fix-sim.t4login.com
                SocketConnectPort=10443
                SSLValidateCertificates=N
                SSLCheckCertificateRevocation=N
                UseSSL=Y
                SSLEnable=Y
                SSLProtocols=Tls12
                HeartBtInt=30
                ReconnectInterval=100
                FileStorePath=..\..\..\..\Trace\logs\
                FileLogPath=..\..\..\..\Trace\store\

                [SESSION]
                BeginString=FIX.4.2
                SenderCompID=T4Example
                TargetCompID=CTS
                StartTime=00:00:00
                EndTime=23:59:59
                ResetOnLogon=Y
                UseDataDictionary=Y
                DataDictionary=QuickFix\FIX42.xml
                MarketDataRequest=Y
                SecurityDefinitionRequest=Y

                [LOG]
                UseScreenLog=Y
                EventLogging=Y
                ScreenLogLevel=5
                ScreenLogShowIncoming=Y
                ScreenLogShowOutgoing=Y

                [VALIDATION]
                ValidateFieldsOutOfOrder=N
                ValidateUserDefinedFields=N
                AllowUnknownMsgFields=Y
                """;

            File.WriteAllText(fullPath, content, Encoding.UTF8);
        }

    }

}
