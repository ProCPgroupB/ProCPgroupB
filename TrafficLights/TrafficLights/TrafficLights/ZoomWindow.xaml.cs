using System;
using System.Collections.Generic;
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
using Microsoft.Win32;

namespace TrafficLights
{
    [Serializable]
    /// <summary>
    /// Interaction logic for ZoomWindow.xaml
    /// </summary>
    public partial class ZoomWindow : Window
    {
        // -------------------------------------  Properties  -------------------------------------
        private Simulation CurrentSimulation;
        private Crossing SelectedCrossing;
        private string activeLane = "";

        public ZoomWindow(Simulation s, Crossing c)
        {
            InitializeComponent();
            CurrentSimulation = s;
            SelectedCrossing = c;

            // Populize the form
            tbTitle.Text = "Cell " + SelectedCrossing.Crossing_ID + " - " + SelectedCrossing.CrossingType.ToString();
            loadMap();
            generateButton();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void loadMap()
        {
            BitmapImage bi = new BitmapImage();

            if (SelectedCrossing.CrossingType == EnumSelectedCrossing.withoutPedestrian)
            {
                //Load image without pedestrian
                bi = new BitmapImage(new Uri("pack://application:,,,/TrafficLights;component/Resources/map1.png", UriKind.Absolute));
            }
            else if (SelectedCrossing.CrossingType == EnumSelectedCrossing.withPedestrian)
            {
                bi = new BitmapImage(new Uri("pack://application:,,,/TrafficLights;component/Resources/map2.png", UriKind.Absolute));

            }
            else
            {
                MessageBox.Show("Image Could Not Be Loaded!");
            }
            Image bImage = new Image
            {
                Width = 600,
                Height = 600,
                Name = "map",
                Source = bi,
            };
            mapCanvas.Children.Add(bImage);
        }

        private void generateButton()
        {
            // North
            double left = (mapCanvas.Width - btnNorth.Width) / 2;
            double top = 100 - (btnNorth.Height / 2);

            // North
            Canvas.SetLeft(btnNorth, left);
            Canvas.SetTop(btnNorth, top);

            // South
            double bottom = 100 - (btnSouth.Height / 2);
            Canvas.SetLeft(btnSouth, left);
            Canvas.SetBottom(btnSouth, bottom);

            // West
            top = (mapCanvas.Height - btnWest.Width) / 2;
            left = 100 - (btnNorth.Height / 2);
            Canvas.SetLeft(btnWest, left);
            Canvas.SetTop(btnWest, top);

            // East
            double right = 100 - (btnWest.Height / 2);
            Canvas.SetRight(btnEast, right);
            Canvas.SetTop(btnEast, top);


            // Setting ZIndex
            Canvas.SetZIndex(btnNorth, 2);
            Canvas.SetZIndex(btnSouth, 2);
            Canvas.SetZIndex(btnEast, 2);
            Canvas.SetZIndex(btnWest, 2);
        }

        private void ZoomWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnNorth_Click(object sender, RoutedEventArgs e)
        {
            activeLane = "North Lane";
            tbLane.Text = activeLane;
        }

        private void btnSouth_Click(object sender, RoutedEventArgs e)
        {
            activeLane = "South Lane";
            tbLane.Text = activeLane;
        }

        private void btnWest_Click(object sender, RoutedEventArgs e)
        {
            activeLane = "West Lane";
            tbLane.Text = activeLane;
        }

        private void btnEast_Click(object sender, RoutedEventArgs e)
        {
            activeLane = "East Lane";
            tbLane.Text = activeLane;
        }
    }
}
