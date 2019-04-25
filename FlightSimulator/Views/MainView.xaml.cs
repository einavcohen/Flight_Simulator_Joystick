using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            JoystickControl jc = new JoystickControl();
            InitializeComponent();
            this.DataContext = jc;
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

