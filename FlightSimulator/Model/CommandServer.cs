using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulator.Model
{
    public class CommandServer
    {
        #region Singleton
        private static CommandServer m_Instance = null;
        public static CommandServer Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new CommandServer();
                return m_Instance;
            }
        }
        #endregion
        private int port;
        private TcpClient client = null;
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
            if (client != null)
            {
                NetworkStream stream = client.GetStream();
                StreamWriter message = new StreamWriter(stream);
                message.WriteLine(pp_name);
                message.Flush();
            }
            
        }

        public void Stop()
        {
            client.Close();
            isAlive = false;
        }
    }
}
