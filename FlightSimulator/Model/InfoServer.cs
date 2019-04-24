/*
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace FlightSimulator.Model
{
    class InfoServer : BaseNotify
    {
        private static InfoServer infoServer = null;

        private float lat;
        private float lon;
        private TcpListener listener;
        public Action<float,float> changedLonLat;

        public float Lat {

            get { return lat;}

            set {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        public float Lon {

            get { return lon;}

            set {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        public void Start()
        {
            int Port = ApplicationSettingsModel.Instance.FlightInfoPort;
            string IP = ApplicationSettingsModel.Instance.FlightServerIP;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5400);
            listener = new TcpListener(ep);
            Console.WriteLine("Waiting for client connections...");
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");
            Thread thread = new Thread(() => {
                try{
                    StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8);
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {

                            string[] valuesStr = line.Split(',');
                            Lon = float.Parse(valuesStr[0]);
                            Lat = float.Parse(valuesStr[1]);

                            Console.WriteLine("lon:" + Lon +" ,lat:" + Lat);

                            changedLonLat?.Invoke(Lon, Lat);
                            reader.DiscardBufferedData();
                    }
                }
                catch(Exception exception){

                }
            });

            //start listenning thread
            thread.Start();
       }                                          
       
        public void Stop()
        {
            listener.Stop();
        }
    }

}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
    public sealed class InfoServer : BaseNotify
    {
        public static readonly InfoServer instance = new InfoServer();
        private TcpListener listener;
        private string[] valuesFromSim = new string[23];
        private double lon;
        private double lat;
        private bool shouldContinue = true;

        string[] ValuesFromSim
        {
            get { return this.valuesFromSim; }
            set { this.ValuesFromSim = value; }
        }

        public double Lon
        {
            get
            {
                return lon;
            }
            set
            {
                lon = value;
                NotifyPropertyChanged("lon");
            }
        }

        public double Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
                NotifyPropertyChanged("lat");
            }
        }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static InfoServer()
        {
        }

        public InfoServer()
        {
            Connect();
            HandleClient();
        }

        public static InfoServer Instance
        {
            get
            {
                return instance;
            }
        }

        public void Connect()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5400);
            listener = new TcpListener(ep);
            listener.Start();
            MessageBox.Show("after start");
        }

        public void HandleClient()
        {
            TcpClient client = listener.AcceptTcpClient();
            MessageBox.Show("after connect");
            Thread thread = new Thread(() => ReadFromClient(client));
            thread.Start();
            //ReadFromClient(client);
        }

        void ReadFromClient(TcpClient client)
        {
            Byte[] bytes;
            while (shouldContinue)
            {
                NetworkStream ns = client.GetStream();
                if (client.ReceiveBufferSize > 0)
                {
                    bytes = new byte[client.ReceiveBufferSize];
                    ns.Read(bytes, 0, client.ReceiveBufferSize);
                    string msg = Encoding.ASCII.GetString(bytes); //the message incoming
                    EditMessage(msg);
                    //MessageBox.Show("the func");
                }
            }
            client.Close();
            listener.Stop();
        }

        void EditMessage(string Message)
        {
            string[] splitwords = Message.Split(',');
            this.valuesFromSim = splitwords;
            Lon = Convert.ToDouble(splitwords[0]);
            Lat = Convert.ToDouble(splitwords[1]);
            MessageBox.Show(valuesFromSim[0]);
        }

        public void Stop()
        {
            this.shouldContinue = false;
        }

    }
}



