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
        TcpClient client;
        TcpListener listener;
        private static InfoServer infoServer = null;

        private float lat;

        private float lon;

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

        int Port = ApplicationSettingsModel.Instance.FlightInfoPort;
        string IP = ApplicationSettingsModel.Instance.FlightServerIP;
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), infoServer.Port);
        TcpListener listener = new TcpListener(ep);










    }

}
}
        listener.Start();
        Console.WriteLine("Waiting for client connections...");
        TcpClient client = listener.AcceptTcpClient();
Console.WriteLine("Client connected");
        using (NetworkStream stream = client.GetStream())
        using (BinaryReader reader = new BinaryReader(stream))
        using (BinaryWriter writer = new BinaryWriter(stream))

        Console.WriteLine("Waiting for a number");
        int num = reader.ReadInt32();
Console.WriteLine("Number accepted");
        num *= 2;
        writer.Write(num);
        writer.Flush();

    client.Close();
    listener.Stop();