using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.ComponentModel;


namespace FlightSimulator.ViewModels
{
    class AutoPilotVM : BaseNotify
    {
        public AutoPilotModel apModel {get; set;}

        private Brush bGround;
        public Brush Bground
        {
            get { return bGround; }
            set { this.bGround = value; NotifyPropertyChanged("Bground"); }
        }

        private String apString;
        public String APstring
        {
            get
            {
                return this.apString;
            }
            set
            {
                this.apString = value;
                apModel.CommandString = apString;
                if (value.CompareTo("") != 0)
                    this.Bground = Brushes.LightPink;
                NotifyPropertyChanged(APstring);
            }
        }

        //init color and str
        public AutoPilotVM()
        {
            Bground = Brushes.White;
            this.apModel = new AutoPilotModel();

        }

        private ICommand _okCommand;
        public ICommand OKCommand
        {
            get
            {
                return _okCommand ?? (_okCommand =
                    new CommandHandler(() => OnOKClick()));
            }
        }

        private void OnOKClick()
        {
            new Thread(() =>
            {
               Bground = Brushes.White;
                string[] commandsStr = apModel.CommandString.Split('\n');
                foreach (string cmd in commandsStr)
                {
                    string command = cmd;
                    command += "\r\n";
                    CommandServer.Instance.Send(command);
                    Thread.Sleep(2000);
                }
            }).Start();
        }

        private ICommand _clearCommand;

        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand =
                    new CommandHandler(() => OnClearClick()));
            }
        }

        private void OnClearClick()
        {
           APstring = "";
        }
    }
}
