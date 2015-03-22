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
    /// PedestrianLane class is inheritance of the Lane class
    /// If the lane is part of the edge-crossing, this lane will be used to create a pedestrian stream
    /// </summary>
    class PedestrianLane : Lane
    {
        // -------------------------- Attributes -------------------------
        
        /// <summary>
        /// list of pedestrians object at the lane
        /// </summary>
        private List<Pedestrian> pedestrians;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of PedestrianLane
        /// </summary>
        /// <param name="capacity">total car capacity of the lane</param>
        /// <param name="paths">paths point of the lane</param>
        /// <param name="id">traffic light id, that belongs to the lane</param>
        public PedestrianLane(Point[] path, int capacity, int id)
            : base(path, capacity, id)
        {

        }

        // --------------------------- Methods ---------------------------
        
        /// <summary>
        /// Add pedestrian object to the lane
        /// </summary>
        /// <param name="p">pedestrian object to add</param>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        public void AddPedestrianToLane(Pedestrian p, int x, int y)
        {

        }

    }
}
