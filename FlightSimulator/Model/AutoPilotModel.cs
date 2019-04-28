using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Threading.Tasks;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
    class AutoPilotModel : BaseNotify
    {
        private Brush back;
        private string commandStr;


        public Brush BackgroundColor
        {
            get
            {
                return back;
            }
            set
            {
                back = value;
                NotifyPropertyChanged("BackgroundColor");
            }
        }

        public string CommandString
        {
            get
            {
                return commandStr;
            }
            set
            {
                commandStr = value;
                // if the string is'nt empty change the background to light pink
                if (!string.IsNullOrEmpty(commandStr))
                {
                    BackgroundColor = Brushes.LightPink;
                }
                // if the string is empty change the background to white
                else
                {
                    BackgroundColor = Brushes.White;
                }
                NotifyPropertyChanged("CommandString");
            }
        }
    }
}