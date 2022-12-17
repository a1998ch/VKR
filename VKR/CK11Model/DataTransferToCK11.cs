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

        public void DataTransfer(Server server, int coa, int ioa, float data)
        {
            ASDU newAsdu = new ASDU(server.GetConnectionParameters(), CauseOfTransmission.PERIODIC, false, false, 1, coa, false);
            InformationObject io = new MeasuredValueShort(ioa, data, new QualityDescriptor());
            newAsdu.AddInformationObject(io);

            server.EnqueueASDU(newAsdu);
        }
    }
}
