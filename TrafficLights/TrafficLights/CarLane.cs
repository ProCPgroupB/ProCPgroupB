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
    /// CarLane class is inheritance of the Lane class
    /// If the lane is part of the edge-crossing, this lane will be used to create a car stream
    /// </summary>
    class CarLane : Lane
    {
        // -------------------------- Attributes -------------------------
        
        /// <summary>
        /// lane direction at the crossing
        /// </summary>
        private EnumDirection direction;

        /// <summary>
        /// a list of cars in the lane
        /// </summary>
        private List<Car> laneCars;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of car lane
        /// </summary>
        /// <param name="direction">direction of the lane</param>
        /// <param name="capacity">total car capacity of the lane</param>
        /// <param name="paths">paths point of the lane</param>
        /// <param name="id">traffic light id, that belongs to the lane</param>
        public CarLane(EnumDirection direction, int capacity, Point[] path, int id)
            : base(path, capacity, id)
        {

        }

        // --------------------------- Methods ---------------------------

        /// <summary>
        /// Add a new car object to the lane
        /// </summary>
        /// <param name="car">car object</param>
        /// <param name="laneIndex">index of the lane</param>
        public void AddCarToLane(Car car, int laneIndex)
        {

        }


    }
}
