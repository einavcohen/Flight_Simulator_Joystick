using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimulator.Model.Interface;


namespace FlightSimulator.ViewModels.Windows
{
    public class FlightProp : BaseNotify
    {
        private FlightPropModel model;

        public FlightProp()
        {
        }

        public float Aileron
        {
            set
            {
                model.Aileron = value;
                NotifyPropertyChanged("Aileron");
            }
        }

        public float Rudder
        {
            set
            {
                model.Rudder = value;
                NotifyPropertyChanged("Rudder");
            }
        }

        public float Elevator
        {
            set
            {
                model.Elevator = value;
                NotifyPropertyChanged("Elevator");
            }
        }

        public float Throttle
        {
            set
            {
                model.Throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }

    }
}
