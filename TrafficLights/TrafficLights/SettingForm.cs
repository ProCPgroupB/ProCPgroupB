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
    public partial class SettingForm : Form
    {
        // -------------------------- Attributes --------------------------
        private Simulation currentSimulation;
        private Setting settings;

        // ------------------------- Constructor -------------------------
        public SettingForm(Simulation s)
        {
            InitializeComponent();
            currentSimulation = s;
            settings = new Setting(this);
        }


        // --------------------------- Methods ---------------------------


    }
}
