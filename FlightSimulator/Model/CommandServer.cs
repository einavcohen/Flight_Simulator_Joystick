using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class CommandServer
    {
        private int port;
        private TcpClient client;
        bool isAlive = false;
        public void Start()
        {
            Task task = new Task(() => {
                while (true)
                {
                    try
                    {
                        TcpClient clientTest = new TcpClient(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightCommandPort);
                        client = clientTest;
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
            });
            task.Start();
            isAlive = true;
        }

        public void Send(string pp_name)
        {
            NetworkStream stream = client.GetStream();
            StreamWriter message = new StreamWriter(stream);
            message.Write(pp_name);
        }

        public void Stop()
        {
            client.Close();
            isAlive = false;
        }
    }
}
