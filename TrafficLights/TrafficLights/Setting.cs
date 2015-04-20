using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights
{
    class Setting
    {
        // -------------------------- Attributes --------------------------

        private SettingForm settingForm;
        private Crossing selectedCrossing;
        private string filePath;
        public int TimeDuration { get; set; }


        // ------------------------- Constructor -------------------------

        public Setting(SettingForm settingForm)
        {
            this.settingForm = settingForm;
        }
        
        // --------------------------- Methods ---------------------------

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
        /// </summary>
        /// <param name="op">operator</param>
        /// <param name="number">number of the cars</param>
        public void setCarNumbers(string op, int number)
        {

        }
        /// <summary>
        /// It will set numbers of pedestrians according to which button is 
        /// </summary>
        /// <param name="op">operator</param>
        /// <param name="number">number of the cars</param>
        public void setPedestrianNumbers(string op, int number)
        {

        }

        public void setCrossing(Crossing c)
        {
            selectedCrossing = c;
        }

        /// <summary>
        /// it is setting the time to a default time of 3 milleseconds
        /// </summary>
        /// <param name="time"></param>
        public void setLightDuration(int time)
        {
            this.TimeDuration = time;
        }

        /// <summary>
        /// will rotate the map
        /// </summary>
        public void Rotate() { }
    }
}
