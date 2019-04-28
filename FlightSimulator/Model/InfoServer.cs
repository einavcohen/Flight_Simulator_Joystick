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
using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
    public sealed class InfoServer : BaseNotify
    {
        private TcpListener listener;
        private string[] valuesFromSim = new string[23];
        private double lon;
        private double lat;
        private bool isAlive;
<<<<<<< HEAD

        #region Singleton
        private static InfoServer m_Instance = null;
        public static InfoServer Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new InfoServer();
                }
                return m_Instance;
            }
        }
        #endregion
=======
>>>>>>> c63bbd764a4f8ff3adc95f4f18f3c737234ff3c9

        #region Singleton
        private static InfoServer m_Instance = null;
        public static InfoServer Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new InfoServer();
                }
                return m_Instance;
            }
        }
        #endregion

        string[] ValuesFromSim
        {
            get { return this.valuesFromSim; }
            set { this.ValuesFromSim = value; }
        }

        public double Lon
        {
            get { return lon; }
            set { lon = value; NotifyPropertyChanged("Lon"); }
        }

        public double Lat
        {
<<<<<<< HEAD
            get {return lat;}
            set {lat = value; NotifyPropertyChanged("Lat");}
<<<<<<< HEAD
=======
        }

        // static constructor in order to tell C# comp
        // not to mark type as before init
        public InfoServer() { }

        static InfoServer(){ }


        public static InfoServer Instance
        {
            get {return instance;}
>>>>>>> c63bbd764a4f8ff3adc95f4f18f3c737234ff3c9
=======
            get { return lat; }
            set { lat = value; NotifyPropertyChanged("Lat"); }
>>>>>>> 4bff969a3c86c2c5302e8b6dfd1dc4a8a98dd3e4
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
<<<<<<< HEAD
<<<<<<< HEAD
            MessageBox.Show("after connect");
            Thread thread = new Thread(() => ReadFromClient(client));
=======
            Thread thread = new Thread(() => ReadFromClient(client,listener));
>>>>>>> c63bbd764a4f8ff3adc95f4f18f3c737234ff3c9
=======
            MessageBox.Show("after connect");
            Thread thread = new Thread(() => ReadFromClient(client));
>>>>>>> 4bff969a3c86c2c5302e8b6dfd1dc4a8a98dd3e4
            thread.Start();
            //ReadFromClient(client);
        }

        void ReadFromClient(TcpClient client)
        {
            Byte[] bytes;
            while (isAlive)
            {
                NetworkStream ns = client.GetStream();
                if (client.ReceiveBufferSize > 0)
                {
                    bytes = new byte[client.ReceiveBufferSize];
                    ns.Read(bytes, 0, client.ReceiveBufferSize);
                    string msg = Encoding.ASCII.GetString(bytes);
                    EditMessage(msg);
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
<<<<<<< HEAD
<<<<<<< HEAD
            catch (Exception exception) { }

            // MessageBox.Show(valuesFromSim[0]);
=======
            catch(Exception exception) { }
            
           // MessageBox.Show(valuesFromSim[0]);
>>>>>>> c63bbd764a4f8ff3adc95f4f18f3c737234ff3c9
=======
            catch (Exception exception) { }

            // MessageBox.Show(valuesFromSim[0]);
>>>>>>> 4bff969a3c86c2c5302e8b6dfd1dc4a8a98dd3e4
        }

        public void Stop()
        {
            this.isAlive = false;
        }

    }
}



