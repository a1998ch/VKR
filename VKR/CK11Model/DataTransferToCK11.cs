using lib60870;

namespace CK11Model
{
    public class DataTransferToCK11
    {
        public Server ConnectServer(string ipAddress, int serverPort)
        {
            Server server = new Server
            {
                DebugOutput = false,
                MaxQueueSize = 10,
                ServerMode = ServerMode.SINGLE_REDUNDANCY_GROUP
            };

            server.SetLocalAddress(ipAddress); // IP-адрес сервера
            server.SetLocalPort(serverPort);
            server.Start();

            return server;
        }

        public void DataTransfer(Server server, int coa, int ioa, float data, bool invalid = false, bool nonTopical = false)
        {
            var Quality = new QualityDescriptor
            {
                Invalid = invalid, // Недействительно
                NonTopical = nonTopical // Неактуально
            };

            ASDU newAsdu = new ASDU(server.GetConnectionParameters(), CauseOfTransmission.PERIODIC, false, false, 1, coa, false);
            InformationObject io = new MeasuredValueShort(ioa, data, Quality);
            newAsdu.AddInformationObject(io);

            server.EnqueueASDU(newAsdu);
        }

        public void StopServer(Server server, string ipAddress, int serverPort)
        {
            server.SetLocalAddress(ipAddress); // IP-адрес сервера
            server.SetLocalPort(serverPort);
            server.Stop();
        }
    }
}
