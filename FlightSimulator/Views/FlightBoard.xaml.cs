using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class FlightBoard : UserControl
    {
        ObservableDataSource<Point> planeLocations = null;
        FlightBoardViewModel viewModel;
        public FlightBoard()
        {
            InitializeComponent();
            this.viewModel = FlightBoardViewModel.Instance;
            this.viewModel.PropertyChanged += Vm_PropertyChanged;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);
            plotter.AddLineGraph(planeLocations, 2, "Route");
        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("VM_Lat") || e.PropertyName.Equals("VM_Lon"))
            {
<<<<<<< HEAD
<<<<<<< HEAD
                Point p1 = new Point(viewModel.VM_Lat, viewModel.VM_Lon);            // Fill here!
                if (p1.X != 0 && p1.Y != 0) planeLocations.AppendAsync(Dispatcher, p1);
=======
                Point p1 = new Point(viewModel.Lat, viewModel.Lon);            // Fill here!
                if(p1.X!=0 && p1.Y!=0) planeLocations.AppendAsync(Dispatcher, p1);

>>>>>>> c63bbd764a4f8ff3adc95f4f18f3c737234ff3c9
=======
                Point p1 = new Point(viewModel.VM_Lat, viewModel.VM_Lon);            // Fill here!
                if (p1.X != 0 && p1.Y != 0) planeLocations.AppendAsync(Dispatcher, p1);
>>>>>>> 4bff969a3c86c2c5302e8b6dfd1dc4a8a98dd3e4
            }
        }
    }

}