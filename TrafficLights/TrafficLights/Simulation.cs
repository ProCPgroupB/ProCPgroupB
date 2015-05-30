using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace TrafficLights
{
    [Serializable]
    public class Simulation
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
            this.fileName = filename;
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
            FileStream fs = null;
            BinaryFormatter bf = null;
            try
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                bf = new BinaryFormatter();
                bf.Serialize(fs, this);
            }
            catch (SerializationException SE)
            {
                //  MessageBox.Show("Unexpected error: " + SE.Message);
            }
            catch (IOException IO)
            {
                // MessageBox.Show("Unexpected error: " + IO.Message);
            }
            finally
            {
                if (fs != null) fs.Close();
                //string filename = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                // this.Text = filename;
            }
        }

        /// <summary>
        /// Load the simulation from the given path 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Simulation loadFile(string path)
        {
            FileStream fs = null;
            BinaryFormatter bf = null;
            Simulation s = null;

            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            bf = new BinaryFormatter();
            while (fs.Position < fs.Length)
            {
                //s = (Simulation)(bf.Deserialize(fs));
                s = (Simulation)(bf.Deserialize(fs));

            }
            return s;
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
