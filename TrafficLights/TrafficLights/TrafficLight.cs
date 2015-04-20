using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights
{
    class TrafficLight
    {

        // -------------------------- Attributes --------------------------/
        /// <summary>
        /// The propertie of the Traffic Lights
        /// </summary>
        public EnumLights LightState { get; set; }

        public int TimeDuration { get; set; }

        // ------------------------- Constructor -------------------------
        /// <summary>
        /// Will initialize the sate of the traffilight 
        /// To red by default
        /// </summary>
        ///
        public TrafficLight()
        {
            LightState = EnumLights.red;
            
        }
        
      

    }
}
