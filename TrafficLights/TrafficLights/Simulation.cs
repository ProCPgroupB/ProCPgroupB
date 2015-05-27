using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights
{
    class Simulation
    {
        // -------------------------- Attributes --------------------------
        private string fileName;
        private string filePath;
        //private Setting setting;
        private TrafficControl control;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// it set the given path, where to save the file
        /// </summary>
        /// <param name="pathFile"></param>
        public Simulation(string filename, string pathFile)
        {
            this.filePath = pathFile;
            this.control = new TrafficControl();
        }

        // --------------------------- Methods ---------------------------

        public TrafficControl Control
        {
            get { return control; }
            set { control = value; }
        }

        /// <summary>
        /// save the simulation to the given path
        /// </summary>
        /// <param name="path"></param>
        public void saveFile(string path)
        {

        }

        /// <summary>
        /// Load the simulation from the given path 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Simulation loadFile(string path)
        {
            return null;
        }

        /// <summary>
        /// it is fasforwading the simulation
        /// </summary>
        public void fastForward() { }

        /// <summary>
        /// Start the simulation
        /// </summary>
        public bool PlaySimulation()
        {
            return true;
        }

        /// <summary>
        /// Pause the simulation
        /// </summary>
        public void PauseSimulation() { }

        /// <summary>
        /// Stop the simulation
        /// </summary>
        public void StopSimulation() { }

        
    }
}
