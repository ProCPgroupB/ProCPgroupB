using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace TrafficLights
{
    [Serializable]
    public partial class MainForm : Form
    {
        // -------------------------------------  Properties  -------------------------------------
        // Simulation
        private Simulation Sim = new Simulation("TrafficLight", "");
        private string simStatus;
        private int time = 0;
        private int timePerSecond = 0;

        // Crossing 
        private int crossingWidth;
        private int crossingHeight;
        private EnumSelectedCrossing selectedCrossing;
        private Crossing tempCrossing;
        private object tempSender;
        private Image tempImage;

        // Lights
        private Size lightSize;
        private RectangleF lightShapes = new RectangleF();
        private Brush lightColor;

        // -------------------------------------  Constructor  -------------------------------------
        public MainForm()
        {
            InitializeComponent();
            ApplyTheme();
            ApplyDrop();
            ApplyGrid();

            SetDoubleBuffered(gridPanel);

            timerTraffic.Interval = 50;
        }

        // -------------------------------------  Methods  -------------------------------------
        public void ApplyTheme()
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
  
            string backgroundCode = "#34495e";
            string sidebarCode = "#c5eff7";

            this.BackColor = System.Drawing.ColorTranslator.FromHtml(backgroundCode);
            sideBar.BackColor = System.Drawing.ColorTranslator.FromHtml(sidebarCode);
            sideBar.Height = this.Height;
        }
        public void ApplyDrop()
        {
            A1.AllowDrop = true;
            A2.AllowDrop = true;
            A3.AllowDrop = true;
            A4.AllowDrop = true;
            A5.AllowDrop = true;
            B1.AllowDrop = true;
            B2.AllowDrop = true;
            B3.AllowDrop = true;
            B4.AllowDrop = true;
            B5.AllowDrop = true;
            C1.AllowDrop = true;
            C2.AllowDrop = true;
            C3.AllowDrop = true;
            C4.AllowDrop = true;
            C5.AllowDrop = true;
        }
        public void ApplyGrid()
        {
            //SetDoubleBuffered(gridPanel);

            A1.Image = Properties.Resources.grid;
            A2.Image = Properties.Resources.grid;
            A3.Image = Properties.Resources.grid;
            A4.Image = Properties.Resources.grid;
            A5.Image = Properties.Resources.grid;

            B1.Image = Properties.Resources.grid;
            B2.Image = Properties.Resources.grid;
            B3.Image = Properties.Resources.grid;
            B4.Image = Properties.Resources.grid;
            B5.Image = Properties.Resources.grid;

            C1.Image = Properties.Resources.grid;
            C2.Image = Properties.Resources.grid;
            C3.Image = Properties.Resources.grid;
            C4.Image = Properties.Resources.grid;
            C5.Image = Properties.Resources.grid;
        }

        #region sidebar crossing
        private void type1_MouseDown(object sender, MouseEventArgs e)
        {
            if (simStatus != "run")
            {
                selectedCrossing = EnumSelectedCrossing.withoutPedestrian;
                type1.DoDragDrop(type1.Image, DragDropEffects.Copy);
            }
            else
            {
                MessageBox.Show("Simulation is running!");
            }
        }
        private void type2_MouseDown(object sender, MouseEventArgs e)
        {
            if (simStatus != "run")
            {
                selectedCrossing = EnumSelectedCrossing.withPedestrian;
                type2.DoDragDrop(type2.Image, DragDropEffects.Copy);
            }
            else
            {
                MessageBox.Show("Simulation is running!");
            }
        }

        #endregion

        // -------------------------------------  Adding Crossing  -------------------------------------
        private void AddCrossing(PictureBox sender, DragEventArgs e)
        {
            int row = gridPanel.GetCellPosition((Control)sender).Row;
            int col = gridPanel.GetCellPosition((Control)sender).Column;

            if (Sim.Control.GetCrossing(row, col) != null)
            {
                DialogResult box = MessageBox.Show("Replace Crossing?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (box.ToString() == "Yes")
                {
                    // Save
                    sender.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
                    sender.SizeMode = PictureBoxSizeMode.StretchImage;

                    Sim.Control.AddCrossing(selectedCrossing.ToString(), row, col);
                }
                else if (box.ToString() == "No")
                {
                    sender.Image = tempImage;
                    sender.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                sender.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
                sender.SizeMode = PictureBoxSizeMode.StretchImage;

                Sim.Control.AddCrossing(selectedCrossing.ToString(), row, col);
            }
            sender.Invalidate();
        }
        
        // -------------------------------------  Deleting Crossing  -------------------------------------
        private void DeleteCrossing(object o, Crossing c)
        {
            if (Sim.Control.RemoveCrossing(c.CrossingPosition.X, c.CrossingPosition.Y))
            {
                ((PictureBox)o).Image = Properties.Resources.grid;
            }
            tempCrossing = null;
            tempSender = null;
        }

        // -------------------------------------  Editing Crossing  -------------------------------------
        private void EditCrossing(object o, Crossing c)
        {
            ZoomForm zm = new ZoomForm(c, Sim.Control.GetConnection(new Point(c.CrossingPosition.X, c.CrossingPosition.Y)));
            zm.StartPosition = FormStartPosition.Manual;
            zm.Location = new Point(270, 70);
            zm.ShowDialog();

            tempCrossing = null;
            tempSender = null;
        }

        // -------------------------------------  Drag & Drop  -------------------------------------
        #region DragDrop
        private void A1_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void A2_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void A3_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void A4_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void A5_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void B1_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void B2_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void B3_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void B4_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void B5_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void C1_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void C2_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void C3_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void C4_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }
        private void C5_DragDrop(object sender, DragEventArgs e) { AddCrossing((PictureBox)sender, e); }

        #endregion

        #region DragEnter
        private void A1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = A1.Image;
            A1.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            A1.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }
        private void A2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = A2.Image;
            A2.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            A2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void A3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = A3.Image;
            A3.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            A3.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void A4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = A4.Image;
            A4.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            A4.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void A5_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = A5.Image;
            A5.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            A5.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void B1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = B1.Image;
            B1.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            B1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void B2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = B2.Image;
            B2.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            B2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void B3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = B3.Image;
            B3.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            B3.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void B4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = B4.Image;
            B4.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            B4.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void B5_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = B5.Image;
            B5.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            B5.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void C1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = C1.Image;
            C1.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            C1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void C2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = C2.Image;
            C2.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            C2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void C3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = C3.Image;
            C3.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            C3.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void C4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = C4.Image;
            C4.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            C4.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void C5_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            tempImage = C5.Image;
            C5.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            C5.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        #endregion

        #region DragLeave
        private void A1_DragLeave(object sender, EventArgs e) { A1.Image = tempImage; }
        private void A2_DragLeave(object sender, EventArgs e) { A2.Image = tempImage; }
        private void A3_DragLeave(object sender, EventArgs e) { A3.Image = tempImage; }
        private void A4_DragLeave(object sender, EventArgs e) { A4.Image = tempImage; }
        private void A5_DragLeave(object sender, EventArgs e) { A5.Image = tempImage; }

        private void B1_DragLeave(object sender, EventArgs e) { B1.Image = tempImage; }
        private void B2_DragLeave(object sender, EventArgs e) { B2.Image = tempImage; }
        private void B3_DragLeave(object sender, EventArgs e) { B3.Image = tempImage; }
        private void B4_DragLeave(object sender, EventArgs e) { B4.Image = tempImage; }
        private void B5_DragLeave(object sender, EventArgs e) { B5.Image = tempImage; }

        private void C1_DragLeave(object sender, EventArgs e) { C1.Image = tempImage; }
        private void C2_DragLeave(object sender, EventArgs e) { C2.Image = tempImage; }
        private void C3_DragLeave(object sender, EventArgs e) { C3.Image = tempImage; }
        private void C4_DragLeave(object sender, EventArgs e) { C4.Image = tempImage; }
        private void C5_DragLeave(object sender, EventArgs e) { C5.Image = tempImage; }

        #endregion

        #region Paint
        private void A1_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 0, 0);
                    drawCars(e, 0, 0);
                    if (Sim.Control.GetCrossing(0, 0) is WithPedestrian)
                    {
                        drawPedestrians(e, 0, 0);
                    }
                }
            }
        }
        private void A2_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 0, 1);
                    drawCars(e, 0, 1);
                    if (Sim.Control.GetCrossing(0, 1) is WithPedestrian)
                    {
                        drawPedestrians(e, 0, 1);
                    }
                }
            }
        }
        private void A3_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 0, 2);
                    drawCars(e, 0, 2);
                    if (Sim.Control.GetCrossing(0, 2) is WithPedestrian)
                    {
                        drawPedestrians(e, 0, 2);
                    }
                }
                
            }
        }
        private void A4_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 0, 3);
                    drawCars(e, 0, 3);
                    if (Sim.Control.GetCrossing(0, 3) is WithPedestrian)
                    {
                        drawPedestrians(e, 0, 3);
                    }
                }
            }
        }
        private void A5_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 0, 4);
                    drawCars(e, 0, 4);
                    if (Sim.Control.GetCrossing(0, 4) is WithPedestrian)
                    {
                        drawPedestrians(e, 0, 4);
                    }
                }
            }
        }

        private void B1_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 1, 0);
                    drawCars(e, 1, 0);
                    if (Sim.Control.GetCrossing(1, 0) is WithPedestrian)
                    {
                        drawPedestrians(e, 1, 0);
                    }
                }
            }
        }
        private void B2_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 1, 1);
                    drawCars(e, 1, 1);
                    if (Sim.Control.GetCrossing(1, 1) is WithPedestrian)
                    {
                        drawPedestrians(e, 1, 1);
                    }
                }
            }
        }
        private void B3_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 1, 2);
                    drawCars(e, 1, 2);
                    if (Sim.Control.GetCrossing(1, 2) is WithPedestrian)
                    {
                        drawPedestrians(e, 1, 2);
                    }
                }
            }
        }
        private void B4_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 1, 3);
                    drawCars(e, 1, 3);
                    if (Sim.Control.GetCrossing(1, 3) is WithPedestrian)
                    {
                        drawPedestrians(e, 1, 3);
                    }
                }
            }
        }
        private void B5_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 1, 4);
                    drawCars(e, 1, 4);
                    if (Sim.Control.GetCrossing(1, 4) is WithPedestrian)
                    {
                        drawPedestrians(e, 1, 4);
                    }
                }
            }
        }

        private void C1_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 2, 0);
                    drawCars(e, 2, 0);
                    if (Sim.Control.GetCrossing(2, 0) is WithPedestrian)
                    {
                        drawPedestrians(e, 2, 0);
                    }
                }
            }
        }
        private void C2_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 2, 1);
                    drawCars(e, 2, 1);
                    if (Sim.Control.GetCrossing(2, 1) is WithPedestrian)
                    {
                        drawPedestrians(e, 2, 1);
                    }
                }
            }
        }
        private void C3_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 2, 2);
                    drawCars(e, 2, 0);
                    if (Sim.Control.GetCrossing(2, 2) is WithPedestrian)
                    {
                        drawPedestrians(e, 2, 2);
                    }
                }
            }
        }
        private void C4_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 2, 3);
                    drawCars(e, 2, 3);
                    if (Sim.Control.GetCrossing(2, 3) is WithPedestrian)
                    {
                        drawPedestrians(e, 2, 3);
                    }
                }
            }
        }
        private void C5_Paint(object sender, PaintEventArgs e)
        {
            bool isExist = (((PictureBox)sender).Image != null) ? true : false;

            if (isExist)
            {
                if (simStatus == "run")
                {
                    drawLights(e, 2, 4);
                    drawCars(e, 2, 4);
                    if (Sim.Control.GetCrossing(2, 4) is WithPedestrian)
                    {
                        drawPedestrians(e, 2, 4);
                    }
                }
            }
        }
        #endregion

        // ------------------------------------- Draw Method  -------------------------------------
        private static void SetDoubleBuffered(Control c)
        {
            System.Reflection.PropertyInfo aProp =
                  typeof(Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }
        
        private void loadCrossing()
        {
            for (int i = 0; i < Sim.Control.GetAllCrossing.GetLength(0); i++)
            {
                for (int j = 0; j < Sim.Control.GetAllCrossing.GetLength(1); j++)
                {
                    Crossing temp = Sim.Control.GetCrossing(i, j);

                    if (temp != null)
                    {
                        string loc = temp.CrossingPosition.X.ToString() + temp.CrossingPosition.Y.ToString();
                        Image tempImg;

                        if (temp.CrossingType == EnumSelectedCrossing.withPedestrian)
                        {
                            tempImg = Properties.Resources.map2n;
                        }
                        else
                        {
                            tempImg = Properties.Resources.map1n;
                        }

                        switch (loc)
                        {
                            case "00":
                                A1.Image = tempImg;
                                A1.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "01":
                                A2.Image = tempImg;
                                A2.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "02":
                                A3.Image = tempImg;
                                A3.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "03":
                                A4.Image = tempImg;
                                A4.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "04":
                                A5.Image = tempImg;
                                A5.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "10":
                                B1.Image = tempImg;
                                B1.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "11":
                                B2.Image = tempImg;
                                B2.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "12":
                                B3.Image = tempImg;
                                B3.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "13":
                                B4.Image = tempImg;
                                B4.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "14":
                                B5.Image = tempImg;
                                B5.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "20":
                                C1.Image = tempImg;
                                C1.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "21":
                                C2.Image = tempImg;
                                C2.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "22":
                                C3.Image = tempImg;
                                C3.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "23":
                                C4.Image = tempImg;
                                C4.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case "24":
                                C5.Image = tempImg;
                                C5.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                        }
                    }
                }
            }
        }

        private void drawLights(PaintEventArgs p, int row, int col)
        {
            Crossing temp = Sim.Control.GetCrossing(row, col);

            if (temp != null)
            {
                foreach (TrafficLight tf in temp.GetState())
                {
                    switch (tf.LightState)
                    {
                        case EnumLights.green:
                            lightShapes.X = tf.GreenPos.X;
                            lightShapes.Y = tf.GreenPos.Y;
                            lightColor = Brushes.LightGreen;
                            break;
                        case EnumLights.yellow:
                            lightShapes.X = tf.YellowPos.X;
                            lightShapes.Y = tf.YellowPos.Y;
                            lightColor = Brushes.Yellow;
                            break;
                        case EnumLights.red:
                            lightShapes.X = tf.RedPos.X;
                            lightShapes.Y = tf.RedPos.Y;
                            lightColor = Brushes.Red;
                            break;
                        default:
                            break;
                    }
                    lightShapes.Size = new Size(4, 4);
                    p.Graphics.FillEllipse(lightColor, lightShapes);
                }
            }
        }

        private void drawCars(PaintEventArgs p, int row, int col)
        {
            Crossing temp = Sim.Control.GetCrossing(row, col);

            if (temp != null)
            {
                float angle = 0;

                foreach (Lane l in temp.CrossingLane)
                {
                    foreach (Car c in l.LaneCars)
                    {
                        c.RotateCar.Reset();

                        Point start = l.Lines[c.NextDots - 1];
                        Point end = l.Lines[c.NextDots];

                        angle = Sim.Control.CalculateAngle(start, end);

                        PointF specPoint = new PointF(c.GetCarObject().Left + (c.GetCarObject().Width / 2), c.GetCarObject().Top + (c.GetCarObject().Height / 2));

                        c.RotateCar.RotateAt(angle, new PointF(c.GetCarObject().Left + (c.GetCarObject().Width / 2), c.GetCarObject().Top + (c.GetCarObject().Height / 2)));

                        p.Graphics.Transform = c.RotateCar;

                        PointF carLoc = c.GetCarObject().Location;
                        RectangleF carShapes = new RectangleF(carLoc, new SizeF(c.GetCarObject().Width - 1, c.GetCarObject().Height));

                        p.Graphics.FillRectangle(c.CarColor, Rectangle.Round(carShapes));

                    }
                }
                moveCars(temp);
            }
        }

        private void drawPedestrians(PaintEventArgs p, int row, int col)
        {
            WithPedestrian temp = (WithPedestrian)Sim.Control.GetCrossing(row, col);

            if (temp != null)
            {
                foreach (Lane l in temp.CrossingLane)
                {
                    foreach (Pedestrian people in l.LanePedestrians)
                    {
                        p.Graphics.ResetTransform();
                        p.Graphics.FillEllipse(people.PedestrianColor, people.GetPedestrianObject());
                    }
                }
                movePedestrians(temp);
            }
        }

        // ------------------------------------- Moving Method  -------------------------------------
        private void movePedestrians(WithPedestrian c)
        {
            float angle;
            foreach (Lane l in c.CrossingLane)
            {
                if (l.TrafficLightIndex > 5)
                {
                    for (int index = 0; index < l.LanePedestrians.Count(); index++)
                    {
                        Pedestrian temp = l.LanePedestrians[index];

                        Point first = l.Lines[temp.NextDots - 1];
                        Point second = l.Lines[temp.NextDots];

                        angle = Sim.Control.CalculateAngle(first, second);

                        PointF nextCoordinates = Sim.Control.MoveObject(temp.PedestrianCoordinates, 2, angle);
                        RectangleF nextObject = new RectangleF(nextCoordinates.X - 1, nextCoordinates.Y - 1, 2, 2);

                        // check if reach next Dot
                        RectangleF nextDotObject = new RectangleF(l.Lines[temp.NextDots].X - 4, l.Lines[temp.NextDots].Y - 4, 16, 8);

                        if (temp.GetPedestrianObject().IntersectsWith(nextDotObject))
                        {
                            temp.NextDots++;
                            if (temp.NextDots == temp.TotalDots)
                            {
                                l.LanePedestrians.RemoveAt(index);
                                goto stopPedestrian;
                            }
                        }

                        // check if intersact with trafficlights
                        TrafficLight tf = c.TrafficLightsList[l.TrafficLightIndex];
                        if (tf.LightState.Equals(EnumLights.green) == false)
                        {
                            int x = tf.ShowTrafficLight.X;
                            int y = tf.ShowTrafficLight.Y;

                            RectangleF r = new RectangleF(x, y, tf.ShowTrafficLight.Width, tf.ShowTrafficLight.Height);

                            if (temp.GetPedestrianObject().IntersectsWith(r))
                            {
                                goto stopPedestrian;
                            }

                        }


                        // Check pedestrians intersact with another or not
                        foreach (Pedestrian pe in l.LanePedestrians)
                        {
                            if (index == 0)
                            {
                                break;
                            }
                            else if (temp != pe && temp.GetPedestrianObject().IntersectsWith(nextObject))
                            {
                                if (temp.GetPedestrianObject().IntersectsWith(l.LanePedestrians[index - 1].GetPedestrianObject()))
                                {
                                    goto stopPedestrian;
                                }
                            }
                        }

                        // if not stopped, assign next dot
                        temp.PedestrianCoordinates = nextCoordinates;

                    stopPedestrian:
                        continue;
                    }
                }
            }
        }

        private void moveCars(Crossing c)
        {
            float angle;
            
            foreach (Lane l in c.CrossingLane)
            {
                for (int index = 0; index < l.LaneCars.Count(); index++)
                {
                    Car tempCar = l.LaneCars[index];
                    bool carOk = false;

                    Point first = l.Lines[tempCar.NextDots - 1];
                    Point second = l.Lines[tempCar.NextDots];

                    angle = Sim.Control.CalculateAngle(first, second);

                    PointF nextCoordinates = Sim.Control.MoveObject(tempCar.CarCoordinates, 4, angle);
                    RectangleF nextObject = new RectangleF(nextCoordinates.X - 4, nextCoordinates.Y - 4, Car.CarWidth, Car.CarHeight);

                    // check if reach next Dot
                    RectangleF nextDotObject = new RectangleF(l.Lines[tempCar.NextDots].X - 2, l.Lines[tempCar.NextDots].Y - 2, 4, 4);

                    if (tempCar.GetCarObject().IntersectsWith(nextDotObject))
                    {
                        tempCar.NextDots++;
                        //Send to another crossroads
                        if(tempCar.NextDots == tempCar.TotalDots && Sim.Control.toNextCrossing(tempCar, c)){
                              l.RemoveCarFromLane(index);
                              goto stopCar;
                        }
                        else if (tempCar.NextDots == tempCar.TotalDots)
                        {
                            //l.LanePedestrians.RemoveAt(index);
                            tempCar.NextDots--;
                            goto stopCar;
                        }
                        carOk = true;
                    }

                    // check car intersact with trafficlights
                    TrafficLight tf = c.TrafficLightsList[l.TrafficLightIndex];
                    if (tf.LightState.Equals(EnumLights.green) == false)
                    {
                        int x = tf.ShowTrafficLight.X;
                        int y = tf.ShowTrafficLight.Y;

                        RectangleF r = new RectangleF(x, y, tf.ShowTrafficLight.Width, tf.ShowTrafficLight.Height);

                        if (tempCar.GetCarObject().IntersectsWith(r))
                        {
                            goto stopCar;
                        }
                    }

                    // check if intersact with another car
                    foreach (Lane l2 in c.CrossingLane)
                    {
                        foreach (Car tempCar2 in l2.LaneCars)
                        {
                            if (tempCar != tempCar2 && tempCar2.GetCarObject().IntersectsWith(nextObject))
                            {
                                if (tempCar.LaneIndex == 1 && tempCar2.LaneIndex == 8)
                                {
                                    break;
                                }
                                else if (tempCar.LaneIndex == 7 && tempCar2.LaneIndex == 2)
                                {
                                    break;
                                }
                                else
                                {
                                    goto stopCar;
                                }
                            }
                        }
                    }

                    if ((c.CurrentCase == EnumCase.caseAGreen || c.CurrentCase == EnumCase.caseAYellow) && c is WithPedestrian)
                    {
                        foreach (Car c2 in c.CrossingLane[0].LaneCars)
                        {
                            Rectangle r = new Rectangle(c.CrossingLane[2].Lines[1].X - 20, c.CrossingLane[2].Lines[1].Y - 30, 30, 60);
                            if (c2.GetCarObject().IntersectsWith(r))
                            {
                                c.CrossingLane[8].isBlocked = true;
                                break;
                            }
                        }
                        foreach (Car c2 in c.CrossingLane[1].LaneCars)
                        {
                            Rectangle r = new Rectangle(c.CrossingLane[2].Lines[1].X - 20, c.CrossingLane[2].Lines[1].Y - 30, 30, 60);
                            if (c2.GetCarObject().IntersectsWith(r))
                            {
                                c.CrossingLane[8].isBlocked = true;
                                break;
                            }
                        }
                        foreach (Car c2 in c.CrossingLane[6].LaneCars)
                        {
                            Rectangle r = new Rectangle(c.CrossingLane[8].Lines[1].X - 20, c.CrossingLane[2].Lines[1].Y - 30, 30, 60);
                            if (c2.GetCarObject().IntersectsWith(r))
                            {
                                c.CrossingLane[2].isBlocked = true;
                                break;
                            }
                        }
                        foreach (Car c2 in c.CrossingLane[7].LaneCars)
                        {
                            Rectangle r = new Rectangle(c.CrossingLane[8].Lines[1].X - 20, c.CrossingLane[2].Lines[1].Y - 30, 30, 60);
                            if (c2.GetCarObject().IntersectsWith(r))
                            {
                                c.CrossingLane[2].isBlocked = true;
                                break;
                            }
                        }
                    }

                    if (c.CrossingLane[2].isBlocked)
                    {
                        foreach (Car c2 in c.CrossingLane[2].LaneCars)
                        {
                            //if(c2.GetCarObject().IntersectsWith(c.CrossingLane[2].LaneCars
                        }
                    }

                    c.CrossingLane[2].isBlocked = false;
                    c.CrossingLane[8].isBlocked = false;

                    if (carOk) tempCar.CarCoordinates = l.Lines[tempCar.NextDots - 1];
                    else tempCar.CarCoordinates = Sim.Control.MoveObject(tempCar.CarCoordinates, 4, angle); ;

                stopCar:
                    continue;
                
                }
            }
        }
        // ------------------------------------- Sidebar -------------------------------------
        #region simulation buttons
        private void playBtn_Click(object sender, EventArgs e)
        {
            timerTraffic.Start();
            simStatus = "run";
            rightClickMenu.Enabled = false;
            lbSimulation.Text = "Simulation is running...";
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            timerTraffic.Stop();
            simStatus = "paused";
            lbSimulation.Text = "Simulation is paused.";
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timerTraffic.Stop();
            simStatus = "stopped";
        }
        #endregion

        #region files
        private void newBtn_Click(object sender, EventArgs e)
        {
            stopBtn_Click(sender, e);

            DialogResult mbr = MessageBox.Show("Your simulation is not saved yet! Do you want to save it?", "Warning!!!!", MessageBoxButtons.YesNoCancel);
            if (mbr.ToString() == "Yes")
            {
                saveBtn_Click(sender, e);
            }
            if (mbr.ToString() != "Cancel")
            {
                Sim.Control.RemoveAll();
                ApplyGrid();
                simStatus = "";
                tempCrossing = null;
                tempImage = null;
                tempSender = null;
                time = 0;
                timePerSecond = 0;
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load Traffic Simulation Files";
            openFileDialog.CheckPathExists = true;
            openFileDialog.DefaultExt = ".ts";
            openFileDialog.Filter = "Traffic Simulation files (*.ts)|*.ts*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Sim = Sim.loadFile(openFileDialog.FileName);

                loadCrossing();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Simulation Files";
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.DefaultExt = "ts";
            saveFileDialog.Filter = "Traffic Simulation files (*.ts)|*.ts*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Sim.saveFile(saveFileDialog.FileName);
            }
        }
        #endregion

        // ------------------------------------- Timer -------------------------------------
        private void timerTraffic_Tick(object sender, EventArgs e)
        {
            time += ((Timer)sender).Interval;

            if (time == 1000)
            {
                foreach (Crossing c in Sim.Control.GetAllCrossing)
                {
                    if (c != null)
                    {
                        c.ChangeCase(time / 1000);
                    }
                }
                time = 0;

                timePerSecond++;

                foreach (Crossing c in Sim.Control.GetAllCrossing)
                {
                    if (c != null)
                    {
                        // Generate Cars
                        if (c.NorthCars != 0)
                        {
                            if ((timePerSecond) % (Convert.ToInt16(60 / c.NorthCars)) == 0)
                            {
                                Car tempC = new Car(0);
                                c.AddCarToLane(EnumDirection.North, tempC);
                            }
                        }
                        if (c.EastCars != 0)
                        {
                            if ((timePerSecond) % (Convert.ToInt16(60 / c.EastCars)) == 0)
                            {
                                Car tempC = new Car(0);
                                c.AddCarToLane(EnumDirection.East, tempC);
                            }
                        }
                        if (c.SouthCars != 0)
                        {
                            if ((timePerSecond) % (Convert.ToInt16(60 / c.SouthCars)) == 0)
                            {
                                Car tempC = new Car(0);
                                c.AddCarToLane(EnumDirection.South, tempC);
                            }
                        }
                        if (c.WestCars != 0)
                        {
                            if ((timePerSecond) % (Convert.ToInt16(60 / c.WestCars)) == 0)
                            {
                                Car tempC = new Car(0);
                                c.AddCarToLane(EnumDirection.West, tempC);
                            }
                        }

                        // Generate Pedestrians
                        if (c is WithPedestrian)
                        {
                            WithPedestrian wp = (WithPedestrian)c;

                            // P1
                            if (wp.p1Capacity != 0)
                            {
                                if ((timePerSecond) % (Convert.ToInt16(60 / wp.p1Capacity)) == 0)
                                {
                                    Pedestrian tempP = new Pedestrian(0);
                                    c.AddPedestrianToLane(new Pedestrian(0), 12);
                                }
                            }
                            if (wp.p2Capacity != 0)
                            {
                                if ((timePerSecond) % (Convert.ToInt16(60 / wp.p2Capacity)) == 0)
                                {
                                    Pedestrian tempP = new Pedestrian(1);
                                    c.AddPedestrianToLane(new Pedestrian(1), 13);
                                }
                            }
                            if (wp.p3Capacity != 0)
                            {
                                if ((timePerSecond) % (Convert.ToInt16(60 / wp.p3Capacity)) == 0)
                                {
                                    Pedestrian tempP = new Pedestrian(2);
                                    c.AddPedestrianToLane(new Pedestrian(2), 14);
                                }
                            }
                            if (wp.p4Capacity != 0)
                            {
                                if ((timePerSecond) % (Convert.ToInt16(60 / wp.p4Capacity)) == 0)
                                {
                                    Pedestrian tempP = new Pedestrian(3);
                                    c.AddPedestrianToLane(new Pedestrian(3), 15);
                                }
                            }
                        }
                    }
                }
                if (timePerSecond == 60)
                {
                    timePerSecond = 0;
                }
            
            }

            

            if (time > 1000)
            {
                time = 0;
            }
            this.Refresh();
        }

        // ------------------------------------- Form Event -------------------------------------
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult box = MessageBox.Show("Your simulation is not saved yet! Do you want to save it?", "Warning!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (box.ToString() == "Yes")
            {
                saveBtn_Click(sender, e);
            }
            else if (box.ToString() == "No")
            {
                e.Cancel = false;
            }
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            //perX = (float)gridPanel.Width / (605 * 5);
            //perY = (float)gridPanel.Height / (605 * 3);
            lightSize = new Size(Convert.ToInt16(A1.Width / 32), Convert.ToInt16(A2.Height / 2));
            crossingHeight = A1.Height;
            crossingWidth = A1.Width;
        }
        
        // ------------------------------------- Right-Click -------------------------------------

        #region mouseClick
        private void A1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(A1, e.X, e.Y);
                }
            }
        }
        private void A2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(A2, e.X, e.Y);
                }
            }
        }
        private void A3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(A3, e.X, e.Y);
                }
            }
        }
        private void A4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(A4, e.X, e.Y);
                }
            }
        }
        private void A5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(A5, e.X, e.Y);
                }
            }
        }

        private void B1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(B1, e.X, e.Y);
                }
            }
        }
        private void B2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(B2, e.X, e.Y);
                }
            }
        }
        private void B3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(B3, e.X, e.Y);
                }
            }
        }
        private void B4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(B4, e.X, e.Y);
                }
            }
        }
        private void B5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(B5, e.X, e.Y);
                }
            }
        }

        private void C1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(C1, e.X, e.Y);
                }
            }
        }
        private void C2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(C2, e.X, e.Y);
                }
            }
        }
        private void C3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(C3, e.X, e.Y);
                }
            }
        }
        private void C4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(C4, e.X, e.Y);
                }
            }
        }
        private void C5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = gridPanel.GetCellPosition((Control)sender).Row;
                int col = gridPanel.GetCellPosition((Control)sender).Column;

                tempCrossing = Sim.Control.GetCrossing(row, col);
                tempSender = sender;

                if (tempCrossing != null)
                {
                    rightClickMenu.Show(C5, e.X, e.Y);
                }
            }
        }
        #endregion

        private void rightClickMenu_Opening(object sender, CancelEventArgs e)
        {
            if (simStatus != "run")
            {
                rightClickMenu.Enabled = true;
            }
        }

        #region Menu Items
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tempCrossing != null && tempSender != null)
            {
                EditCrossing(tempSender, tempCrossing);
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tempCrossing != null && tempSender != null)
            {
                DeleteCrossing(tempSender, tempCrossing);
            }
        }
        #endregion

        


    }
}

