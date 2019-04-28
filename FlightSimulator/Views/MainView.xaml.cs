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
        private JoystickControl jc;
        public MainView()
        {
            InitializeComponent();
            jc = JoystickControl.Instance;
            DataContext = jc;
        }

        private void StartServer(object sender, RoutedEventArgs e)
        {
            MainViewVM mv = MainViewVM.Instance;
            mv.startServerVM();
        }

        private void ChangeSet(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
        }
        
    }
}

