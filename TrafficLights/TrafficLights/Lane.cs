using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TrafficLights
{
    /// <summary>
    /// this class create lane object. Lane is a part of crossing that have its own 
    /// traffic lights, car stream, and pedestrian stream. 
    /// </summary>
    class Lane
    {
        // -------------------------- Attributes -------------------------
        
        /// <summary>
        /// the paths point of the lane
        /// </summary>
        private Point[] paths;

        /// <summary>
        /// the capacity of cars/pedestrian of the lane
        /// </summary>
        private int capacity;

        /// <summary>
        /// the id of traffic light at the lane
        /// </summary>
        private int trafficLightID;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of the lane
        /// </summary>
        /// <param name="paths">paths point of the lane</param>
        /// <param name="id">traffic light id, that belongs to the lane</param>
        public Lane(Point[] paths, int capacity, int id)
        {
            this.paths = paths;
            this.capacity = capacity;
            this.trafficLightID = id;
        }

    }
}
