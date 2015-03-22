using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights
{
    class Setting
    {
        // Fields
        private Crossing selectedCrossing;
        private string filePath;

        private List<Simulation> simulationList = new List<Simulation>();
       

        /****************************************Properties*************************************/

        public int TimeDuration { get; set; }

        // Constructor
        public Setting()
        {

        }
        public Setting(Crossing C)
        {

        }

        /***************************** Methods********************************************/
        /// <summary>
        /// The user can set the path where to save the simulation
        /// it will be his default save path 
        /// </summary>
        /// <param name="path"></param>
        public void setFilePath(string path)
        {
            foreach (Simulation defaultPath in simulationList)
            {
                defaultPath.saveFile(path);
            }
        }
      
        /// <summary>
        /// It will set the numbers of cars according to which button is press
        /// Decreasing or increasing 
        /// op-----> operator
        /// </summary>
        /// <param name="op"></param>
        public void setCarNumbers(string op)
        {

        }
        /// <summary>
        /// It will set numbers of pedestrians according to which button is press
        /// op ----> operator
        /// </summary>
        /// <param name="op"></param>
        public void setPedestrianNumbers(string op)
        {

        }

        /// <summary>
        /// it is setting the time to a default time of 3 milleseconds
        /// </summary>
        /// <param name="time"></param>
        public void setLightDuration(int time)
        {
            this.TimeDuration = time;
        }

    }
}
