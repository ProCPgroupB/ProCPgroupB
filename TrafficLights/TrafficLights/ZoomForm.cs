using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLights
{
    public partial class ZoomForm : Form
    {

        // -------------------------- Attributes --------------------------
        private Simulation currentSimulation;
        private Crossing selectedCrossing;

        // ------------------------- Constructor -------------------------
        public ZoomForm(Simulation s, Crossing c)
        {
            InitializeComponent();
            currentSimulation = s;
            selectedCrossing = c;
        }


        // --------------------------- Methods ---------------------------
    }
}
