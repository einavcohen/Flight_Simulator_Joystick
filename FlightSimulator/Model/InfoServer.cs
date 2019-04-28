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
        private bool isAlive;

        string[] ValuesFromSim
        {
            get { return this.valuesFromSim; }
            set { this.ValuesFromSim = value; }
        }

        public double Lon
        {
            get {return lon;}
            set {lon = value; NotifyPropertyChanged("Lon");}
        }

        public double Lat
        {
            get {return lat;}
            set {lat = value; NotifyPropertyChanged("Lat");}
        }

        // static constructor in order to tell C# comp
        // not to mark type as before init
        public InfoServer() { }

        static InfoServer(){ }


        public static InfoServer Instance
        {
            get {return instance;}
        }

        public void Connect()
        {
            isAlive = true;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
                ApplicationSettingsModel.Instance.FlightInfoPort);
            listener = new TcpListener(ep);
            listener.Start();
            HandleClient();
        }

        public void HandleClient()
        {
            TcpClient client = listener.AcceptTcpClient();
            Thread thread = new Thread(() => ReadFromClient(client,listener));
            thread.Start();
        }

        void ReadFromClient(TcpClient client, TcpListener listener)
        {
            Byte[] bytes;
            while (isAlive)
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
            string[] splitStr = Message.Split(',');
            this.valuesFromSim = splitStr;
            try
            {
                Lon = Convert.ToDouble(splitStr[0]);
                Lat = Convert.ToDouble(splitStr[1]);
            }
            catch(Exception exception) { }
            
           // MessageBox.Show(valuesFromSim[0]);
        }

        public void Stop()
        {
            this.isAlive = false;
        }

    }
}



