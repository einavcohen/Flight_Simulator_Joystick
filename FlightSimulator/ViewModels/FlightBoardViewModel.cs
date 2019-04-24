using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        public FlightBoardViewModel()
        {
            InfoServer.Instance.PropertyChanged += PropertyChange;
        }
        public double Lon
        {
            get { return InfoServer.Instance.Lon; }
            set { InfoServer.Instance.Lon = value; }
        }

        public double Lat
        {
            get { return InfoServer.Instance.Lat; }
            set { InfoServer.Instance.Lat = value; }
        }

        public void PropertyChange(object sender, PropertyChangedEventArgs p)
        {
            NotifyPropertyChanged(p.PropertyName);
        }
    }
}