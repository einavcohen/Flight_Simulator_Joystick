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
        public AutoPilotModel autoPilotModel {

            get;

            set;
        }

        //init color and str
        public AutoPilotVM()
        {
            autoPilotModel = new AutoPilotModel();
            autoPilotModel.CommandString = "";
            autoPilotModel.BackgroundColor = Brushes.White;

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
               autoPilotModel.BackgroundColor = Brushes.White;
                string[] commandsStr = autoPilotModel.CommandString.Split('\n');
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
           autoPilotModel.CommandString = "";
           autoPilotModel.BackgroundColor = Brushes.White;
        }
    }
}
