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

        private void ChangeSettings(object sender, RoutedEventArgs e)
        {
            // Create the Grid
            Window mainWindow = new Window();
            mainWindow.Title = "Settings";

            Grid myGrid = new Grid();
            myGrid.Width = 250;
            myGrid.Height = 100;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;

            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();

            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);

            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            RowDefinition rowDef4 = new RowDefinition();

            myGrid.RowDefinitions.Add(rowDef1);
            myGrid.RowDefinitions.Add(rowDef2);
            myGrid.RowDefinitions.Add(rowDef3);
            myGrid.RowDefinitions.Add(rowDef4);

            // Add the first text cell to the Grid
            TextBlock txt1 = new TextBlock();
            txt1.Text = "Flight Server IP:";
            txt1.FontSize = 12;
            txt1.FontWeight = FontWeights.Bold;
            Grid.SetColumn(txt1, 0);
            Grid.SetRow(txt1, 0);

            TextBox box1 = new TextBox();
            Grid.SetColumn(box1, 1);
            Grid.SetRow(box1, 0);
            // Add the second text cell to the Grid
            TextBlock txt2 = new TextBlock();
            txt2.Text = "Flight Info Port:";
            txt2.FontSize = 12;
            txt2.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt2, 1);
            Grid.SetColumn(txt2, 0);

            TextBox box2 = new TextBox();
            Grid.SetColumn(box2, 1);
            Grid.SetRow(box2, 1);
            // Add the third text cell to the Grid
            TextBlock txt3 = new TextBlock();
            txt3.Text = "Flight Command Port:";
            txt3.FontSize = 12;
            txt3.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt3, 2);
            Grid.SetColumn(txt3, 0);

            TextBox box3 = new TextBox();
            Grid.SetColumn(box3, 1);
            Grid.SetRow(box3, 2);

            Button button1 = new Button();
            Button button2 = new Button();
            button1.Content = "OK";
            button2.Content = "Cancel";
            Grid.SetColumn(button1, 0);
            Grid.SetRow(button1, 3);

            Grid.SetColumn(button2, 1);
            Grid.SetRow(button2, 3);

            myGrid.Children.Add(txt1);
            myGrid.Children.Add(txt2);
            myGrid.Children.Add(txt3);
            myGrid.Children.Add(box1);
            myGrid.Children.Add(box2);
            myGrid.Children.Add(box3);
            myGrid.Children.Add(button1);
            myGrid.Children.Add(button2);

            mainWindow.Width = 300;
            mainWindow.Height = 300;
            mainWindow.Content = myGrid;
            mainWindow.Show();
        }
    }
}

