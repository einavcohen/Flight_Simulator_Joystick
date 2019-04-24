using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FlightSimulator.Views;
using FlightSimulator.ViewModels.Windows;
using FlightSimulator.Model;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void StartServer(object sender, RoutedEventArgs e)
        {
            CommandServer cs = new CommandServer();
            InfoServer isr = new InfoServer();
            cs.Start();
            isr.Connect();
            isr.HandleClient();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeSet(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
        }

        #region Commands
        #region ChangeSettings
        private ICommand _changeSettings;
        public ICommand ChangeSettings
        {
            get
            {
                return _changeSettings ?? (_changeSettings = new CommandHandler(() => SettingClick()));
            }
        }

        private void SettingClick()
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
        }
        #endregion
        #endregion
    }
}

