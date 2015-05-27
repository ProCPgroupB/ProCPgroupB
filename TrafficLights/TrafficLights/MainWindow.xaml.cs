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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // -------------------------------------  Properties  -------------------------------------
        // Simulation Configuration
        Simulation Sim = new Simulation("TrafficLights", "Path");
        
        // Grid Properties
        private int cellWidth = 200;
        private int cellHeight = 200;
        private int row = 0;
        private int col = 0;
        private List<Rectangle> cells = new List<Rectangle>();
        private Point startPoint;
        private string crossingType = "";
        
        // -------------------------------------  Constructor  -------------------------------------
        public MainWindow()
        {
            this.MaxHeight = SystemParameters.WorkArea.Height;
            InitializeComponent();
            generateGrid();
        }

        // ------------------------------------  Grid  ----------------------------------------------
        public void generateGrid()
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < canvasGrid.Height; i += 200)
            {
                for (int j = 0; j < canvasGrid.Width; j += 200)
                {
                    Rectangle gridCell = new Rectangle();
                    gridCell.Width = cellWidth;
                    gridCell.Height = cellHeight;

                    gridCell.StrokeThickness = 1;
                    gridCell.Stroke = new SolidColorBrush(Colors.WhiteSmoke);

                    //gridCell.Name = "Grid " + x.ToString() + "" + y.ToString();

                    Canvas.SetTop(gridCell, i);
                    Canvas.SetLeft(gridCell, j);

                    cells.Add(gridCell);
                    //canvasGrid.Children.Add(gridCell);
                    y++;
                }
                x++;
            }
            foreach (var c in cells)
            {
                canvasGrid.Children.Add(c);
            }
        }

        // ------------------------------------  Drag&Drop  ----------------------------------------------
        private void type_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Store the mouse position
            startPoint = e.GetPosition(null);
        }
        private void type_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Image image = e.Source as Image;
            crossingType = image.Name;
            DataObject data = new DataObject(typeof(ImageSource), image.Source);
            DragDrop.DoDragDrop(image, data, DragDropEffects.Copy);
        }
        private void canvasGrid_Drop(object sender, DragEventArgs e)
        {
            // Get position
            Point loc = e.GetPosition(canvasGrid);
            row = (Convert.ToInt32(loc.Y) / cellWidth);
            col = (Convert.ToInt32(loc.X) / cellHeight);

            // Get image
            ImageSource image = e.Data.GetData(typeof(ImageSource)) as ImageSource;
            Image imageControl = new Image() { Width = 200, Height = 200, Source = image };
            imageControl.Uid = row.ToString() + col.ToString();

            // Set image position on canvas
            int x = row * 200;
            int y = col * 200;
            Canvas.SetTop(imageControl, x);
            Canvas.SetLeft(imageControl, y);

            // Check cell
            // if exist
            if (Sim.Control.GetCrossing(row, col) != null)
            {
                // ask permission to replace
                if (MessageBox.Show("Replace crossing?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    //do no stuff
                }
                else
                {
                    if (Sim.Control.AddCrossing(crossingType, row, col))
                    {
                        removeItem(row, col);
                        canvasGrid.Children.Add(imageControl);
                    }
                    else
                    {
                        MessageBox.Show("Cannot add crossing to grid!");
                    }
                }
            }
            else
            {
                // else
                // add image
                if (Sim.Control.AddCrossing(crossingType, row, col))
                {
                    canvasGrid.Children.Add(imageControl);
                }
                else
                {
                    MessageBox.Show("Cannot add crossing to grid!");
                }
            }
        }

        private void dropdownBtn_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        private String Number2String(int number, bool isCaps)
        {
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            return c.ToString();
        }

        // ------------------------------------  Grid Double-Click  ----------------------------------------------
        private void canvasGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Get position
            Point loc = e.GetPosition(canvasGrid);
            row = (Convert.ToInt32(loc.Y) / cellWidth);
            col = (Convert.ToInt32(loc.X) / cellHeight);

            if (e.ClickCount == 2)
            {
                if (Sim.Control.GetCrossing(row, col) != null)
                {
                    ZoomWindow zw = new ZoomWindow();
                    zw.Show();
                }
            }
        }

        // ------------------------------------  Grid Right-Click  ----------------------------------------------
        private void canvasGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Get position
            Point loc = e.GetPosition(canvasGrid);
            row = (Convert.ToInt32(loc.Y) / cellWidth);
            col = (Convert.ToInt32(loc.X) / cellHeight);

            if (Sim.Control.GetCrossing(row, col) != null)
            {
                gridContextMenu.IsOpen = true;
            }
        }

        private void canvasGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        // Right-Click menu item
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if (deteleCrossing(row, col))
            {
                MessageBox.Show("Deleted");
            }
        }
        private void MenuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            if (Sim.Control.GetCrossing(row, col) != null)
            {
                ZoomWindow zw = new ZoomWindow();
                zw.Show();
            }
        }

        // ------------------------------------  Removing Crossing  ----------------------------------------------
        private bool deteleCrossing(int row, int col)
        {
            removeItem(row, col);
            return Sim.Control.RemoveCrossing(row, col);
        }
        private void removeItem(int row, int col)
        {
            UIElement itemstoremove = new UIElement();
            foreach (UIElement ui in canvasGrid.Children)
            {
                if (ui.Uid == row.ToString() + col.ToString())
                {
                    itemstoremove = ui;
                }
            }

            canvasGrid.Children.Remove(itemstoremove);
        }

        // ------------------------------------  Sidebar Menu  ----------------------------------------------
        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                Sim.loadFile(openFileDialog.FileName);
            }
        }

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Your simulation is not saved yet! Do you want to save it?", "Warning!!!!", MessageBoxButton.YesNoCancel);
            if (mbr.ToString() == "Yes")
            {
                
            }
            else if (mbr.ToString() == "No")
            {
                Sim.Control.RemoveAll();
                canvasGrid.Children.Clear();
                generateGrid();
            }

        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {

            }
        }





    }
}
