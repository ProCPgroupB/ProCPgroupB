using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TrafficLights
{

    public partial class ZoomForm : Form
    {
        // -------------------------------------  Properties  -------------------------------------
        Crossing crossingTemp;

        // Car Number
        private int carNorth = 0;
        private int carEast = 0;
        private int carSouth = 0;
        private int carWest = 0;

        // Traffic Time
        private int N1 = 0;
        private int N2 = 0;
        private int E1 = 0;
        private int E2 = 0;
        private int S1 = 0;
        private int S2 = 0;
        private int W1 = 0;
        private int W2 = 0;
        private int P1 = 0;
        private int P2 = 0;

        // Pedestrian Number
        private int pedNorth = 0;
        private int pedSouth = 0;


        // -------------------------------------  Constructor -------------------------------------
        public ZoomForm(Crossing c, bool[] Connection)
        {
            InitializeComponent();

            crossingTemp = c;

            withPanel.Visible = false;
            //withoutPanel.Visible = false;

            string title = "";
            string backgroundCode = "#34495e";
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(backgroundCode);
            withPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(backgroundCode);

            loadData();

            if (carNorth > 0) { btnNorth.Visible = true; } if (carEast > 0) { btnEast.Visible = true; } if (carSouth > 0) { btnSouth.Visible = true; } if (carWest > 0) { btnWest.Visible = true; }


            if (crossingTemp.CrossingType == EnumSelectedCrossing.withoutPedestrian)
            {
                title = "Crossing Without Pedestrian - ";
                
            } else {
                title = "Crossing With Pedestrian - ";
                
            }

            ApplyPanel();

            string id = Number2String(((c.CrossingPosition.X + 1)), true) + (c.CrossingPosition.Y + 1).ToString();

            this.Text = title + id;

            
        }

        // -------------------------------------  Methods -------------------------------------
        private void ApplyPanel()
        {

            if (crossingTemp.CrossingType == EnumSelectedCrossing.withoutPedestrian)
            {
                mapPb.Image = Properties.Resources.map1;
                mapPb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                mapPb.Image = Properties.Resources.map2;
                mapPb.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            withPanel.Visible = true;
            withPanel.Size = new Size(281, 571);

            cbDirection.Text = cbDirection.Items[0].ToString();
        }

        private void loadData()
        {
            carNorth = ((Crossing)crossingTemp).NorthCars;
            carEast = ((Crossing)crossingTemp).EastCars;
            carSouth = ((Crossing)crossingTemp).SouthCars;
            carWest = ((Crossing)crossingTemp).WestCars;

            

            if (crossingTemp.CrossingType == EnumSelectedCrossing.withPedestrian)
            {
                // Pedestrian number
                pedNorth = ((WithPedestrian)crossingTemp).p1Capacity;
                pedSouth = ((WithPedestrian)crossingTemp).p3Capacity;

                // Traffic Time
                N1 = ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseAGreen];
                E1 = ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseAGreen];
                E2 = ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseBGreen];
                S1 = ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseBGreen];
                W1 = ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseCGreen];
                W2 = ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseCGreen];
                P1 = ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseDGreen];
                P2 = ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseDGreen];
            }
            else
            {
                // Traffic Time
                N1 = ((WithoutPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseAGreen];
                N2 = ((WithoutPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseAGreen];
                E1 = ((WithoutPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseAGreen];
                E2 = ((WithoutPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseBGreen];
                S1 = ((WithoutPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseBGreen];
                S2 = ((WithoutPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseBGreen];
                W1 = ((WithoutPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseCGreen];
                W2 = ((WithoutPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseCGreen];
            }
        }

        public String Number2String(int number, bool isCaps)
        {
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            return c.ToString();
        }

        private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDirection.Text == "North")
            {
                btnNorth_Click(sender, e);
            }
            else if (cbDirection.Text == "East")
            {
                btnEast_Click(sender, e);
            }
            else if (cbDirection.Text == "South")
            {
                btnSouth_Click(sender, e);
            }
            else if (cbDirection.Text == "West")
            {
                btnWest_Click(sender, e);
            }
            else
            {

            }
        }



        private void ResetPanel()
        {
            lbPedes.Visible = false;
            cbPedes.Visible = false;

            btnSave.Location = new Point(16, 220);
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            cbDirection.Text = "North";
            
            ResetPanel();

            lbT1.Text = "North1 TL Time";
            cbCar.Text = carNorth.ToString();
            cbT1.Text = N1.ToString();

            if (crossingTemp.CrossingType == EnumSelectedCrossing.withPedestrian)
            {
                btnSave.Location = new Point(16, 284);
                lbPedes.Visible = true;
                cbPedes.Visible = true;
                cbPedes.Text = pedNorth.ToString();
                lbT2.Text = "Ped1 TL Time";
                cbT2.Text = P1.ToString();
            }
            else
            {
                lbT2.Text = "North2 TL Time";
                cbT2.Text = N2.ToString();
            }
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            cbDirection.Text = "East";
            ResetPanel();

            lbT1.Text = "East1 TL Time";
            lbT2.Text = "East2 TL Time";

            cbCar.Text = carEast.ToString();

            cbT1.Text = E1.ToString();
            cbT2.Text = E2.ToString();

        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            cbDirection.Text = "South";
            ResetPanel();

            lbT1.Text = "South1 TL Time";
            cbCar.Text = carNorth.ToString();
            cbT1.Text = S1.ToString();

            if (crossingTemp.CrossingType == EnumSelectedCrossing.withPedestrian)
            {
                btnSave.Location = new Point(16, 284);
                lbPedes.Visible = true;
                cbPedes.Visible = true;
                cbPedes.Text = pedNorth.ToString();
                lbT2.Text = "Ped2 TL Time";
                cbT2.Text = P2.ToString();
            }
            else
            {
                lbT2.Text = "South2 TL Time";
                cbT2.Text = S2.ToString();
            }
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            cbDirection.Text = "West";
            ResetPanel();
            lbT1.Text = "West1 TL Time";
            lbT2.Text = "West2 TL Time";

            cbCar.Text = carWest.ToString();

            cbT1.Text = W1.ToString();
            cbT2.Text = W2.ToString();

        }

        private void cbCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbDirection.Text)
            {
                case "North":
                    carNorth = Convert.ToInt32(cbCar.Text);
                    break;
                case "East":
                    carEast = Convert.ToInt32(cbCar.Text);
                    break;
                case "South":
                    carSouth = Convert.ToInt32(cbCar.Text);
                    break;
                case "West":
                    carWest = Convert.ToInt32(cbCar.Text);
                    break;
                default:
                    break;
            }
        }

        private void cbPedes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbDirection.Text)
            {
                case "North":
                    pedNorth = Convert.ToInt32(cbPedes.Text);
                    break;
                case "South":
                    pedSouth = Convert.ToInt32(cbPedes.Text);
                    break;
                default:
                    break;
            }
        }

        private void cbT1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbDirection.Text)
            {
                case "North":
                    N1 = Convert.ToInt32(cbT1.Text);
                    break;
                case "East":
                    E1 = Convert.ToInt32(cbT1.Text);
                    break;
                case "South":
                    S1 = Convert.ToInt32(cbT1.Text);
                    break;
                case "West":
                    W1 = Convert.ToInt32(cbT1.Text);
                    break;
                default:
                    break;
            }
        }

        private void cbT2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbDirection.Text)
            {
                case "North":
                    if (crossingTemp.CrossingType == EnumSelectedCrossing.withPedestrian)
                    {
                        P1 = Convert.ToInt32(cbT2.Text);
                    }
                    else
                    {
                        N2 = Convert.ToInt32(cbT2.Text);
                    }
                    break;
                case "South":
                    if (crossingTemp.CrossingType == EnumSelectedCrossing.withPedestrian)
                    {
                        P2 = Convert.ToInt32(cbT2.Text);
                    }
                    else
                    {
                        S2 = Convert.ToInt32(cbT2.Text);
                    }
                    break;
                case "East":
                    E2 = Convert.ToInt32(cbT2.Text);
                    break;
                case "West":
                    W2 = Convert.ToInt32(cbT2.Text);
                    break;
                default:
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            ((Crossing)crossingTemp).NorthCars = carNorth;
            ((Crossing)crossingTemp).SouthCars = carSouth;
            ((Crossing)crossingTemp).WestCars = carWest;
            ((Crossing)crossingTemp).EastCars = carEast;

            if (crossingTemp.CrossingType == EnumSelectedCrossing.withPedestrian)
            {
                // Traffic Time
                ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseAGreen] = N1;
                ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseBGreen] = S1;
                ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseBGreen] = S2;
                ((WithPedestrian)crossingTemp).CaseDurations[(int)EnumCase.caseBGreen] = P1;

                // Number of Pedestrian
                ((WithPedestrian)crossingTemp).p1Capacity = pedNorth;
                ((WithPedestrian)crossingTemp).p2Capacity = pedNorth;
                ((WithPedestrian)crossingTemp).p3Capacity = pedSouth;
                ((WithPedestrian)crossingTemp).p4Capacity = pedSouth;
            }

            MessageBox.Show("Saved!");
        }
    }
}
