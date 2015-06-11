using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrafficLights
{
    [Serializable]
    public class TrafficLight
    {

        // -------------------------- Attributes --------------------------/
        /// <summary>
        /// The propertie of the Traffic Lights
        /// </summary>
        public EnumLights LightState { get; set; }

        public int TimeDuration { get; set; }

        public Point GreenPos { get; set; }
        public Point YellowPos { get; set; }
        public Point RedPos { get; set; }

        // ------------------------- Constructor -------------------------
        /// <summary>
        /// Will initialize the sate of the traffilight 
        /// To red by default
        /// </summary>
        ///
        public TrafficLight()
        {
                        
        }

        public Rectangle ShowTrafficLight { get; set; }
        
        
    }
}
