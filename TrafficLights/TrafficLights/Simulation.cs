using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights
{
    class Simulation
    {
        /********************************* Field**********************************/
        private string filePath;
        private List<Car> carList;
        private List<TrafficLight> trafficLightList;
        private List<Pedestrian> pedestriansList;
        // Constructor

        /// <summary>
        /// it set the given path, where to save the file
        /// </summary>
        /// <param name="pathFile"></param>
        public Simulation(string pathFile)
        {
            this.filePath = pathFile;
            this.carList = new List<Car>();
            this.trafficLightList = new List<TrafficLight>();
            this.pedestriansList = new List<Pedestrian>();
        }
        
        /************************ Methods*******************************************/

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
        public void PlaySimulation()
        {
        }

        /// <summary>
        /// Pause the simulation
        /// </summary>
        public void PauseSimulation() { }

        /// <summary>
        /// Stop the simulation
        /// </summary>
        public void StopSimulation() { }

        /// <summary>
        /// will rotate the map
        /// </summary>
        public void Rotate() { }
    }
}
