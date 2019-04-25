using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;


namespace FlightSimulator.ViewModels
{
    class AutoPilotVM :BaseNotify
    {

         //init color and str
        public AutoPilotVM()
        {
            commandString = "";
            BackgroundColor = Brushes.White;

        }

        private Brush back;

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

        private string commandString;

        public string CommandString
        {
            get
            {
                return commandString;
            }
            set
            {
                commandString = value;
                if (!string.IsNullOrEmpty(commandString))
                {
                    BackgroundColor = Brushes.LightPink;
                }
                NotifyPropertyChanged("CommandString");
            }
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
                BackgroundColor = Brushes.White;
                string[] commandsStr = commandString.Split('\n');
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
            commandString = "";
            BackgroundColor = Brushes.White;
        }
    }
}
