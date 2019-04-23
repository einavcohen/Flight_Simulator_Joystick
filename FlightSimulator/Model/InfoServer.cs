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
            listener = new TcpListener(ep);            Console.WriteLine("Waiting for client connections...");            listener.Start();            TcpClient client = listener.AcceptTcpClient();            Console.WriteLine("Client connected");
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
                    }                }                catch(Exception exception){                }            });            //start listenning thread            thread.Start();       }                                          
       
        public void Stop()
        {
            listener.Stop();
        }
    }}



