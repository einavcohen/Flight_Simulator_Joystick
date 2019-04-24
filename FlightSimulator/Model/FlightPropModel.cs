using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.Model
{
    public class FlightPropModel
    {
        private CommandServer cl;
        public FlightPropModel(CommandServer client)
        {
            cl = client;
        }
        public float Aileron
        {
            set
            {
                cl.Send("set /controls/flight/aileron " + value);
            }
        }
        public float Rudder
        {
            set
            {
                cl.Send("set /controls/flight/elevator " + value);
            }
        }
        public float Elevator
        {
            set
            {
                cl.Send("set /controls/flight/rudder " + value);
            }
        }
        public float Throttle
        {
            set
            {
                cl.Send("set /controls/engines/current-engine/throttle " + value);
            }
        }
    }
}
