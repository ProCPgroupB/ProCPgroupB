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
    /// This class create a crossing object. 
    /// </summary>
    class Crossing
    {
        // -------------------------- Attributes --------------------------

        List<Pedestrian> ListPedestrian = new List<Pedestrian>();

        /// <summary>
        /// list of lanes in the crossing
        /// </summary>
        List<Lane> lanes;

        /// <summary>
        /// crossing ID is the crossing is (not location)
        /// </summary>
        private int crossing_ID;

        /// <summary>
        /// type of the crossing // change to enum to determine the crossing
        /// </summary>
        // private int crossingType;
        private EnumSelectedCrossing crossingType;
        /// <summary>
        /// position of the crossing
        /// </summary>
        private Point crossingPosition;

        /// <summary>
        /// a list of cars inside the crossing
        /// </summary>
        private Car[] cars;

        /// <summary>
        /// a list of crossing that connected to this crossing
        /// </summary>
        private Crossing[] connections;

        /// <summary>
        /// current case that working in the crossing
        /// </summary>
        private EnumCase currentCase;

        /// <summary>
        /// a property to define crossing is a source of car/pedestrian or not
        /// </summary>
        private bool isSource;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of the crossing
        /// </summary>
        /// <param name="type">type of the crossing</param>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        public Crossing(EnumSelectedCrossing type, int row, int col)
        {
            this.crossingType = type;
            this.crossingPosition = new Point(row, col);
            //this.crossing_ID = cross_ID;
        }

        // --------------------------- Methods ---------------------------

        ///// <summary>
        ///// add a new car to the crossing based on the lane direction
        ///// </summary>
        ///// <param name="direction"></param>
        ///// <param name="c"></param>
        //public void AddCar(EnumLaneDirection direction, Car c)
        //{

       // //}

       // /// <summary>
       // ///  change crossing case based on time in the simulation
       // /// </summary>
       // /// <param name="time">timer</param>
       // public void ChangeCase(int time){}

       // /// <summary>
       // /// get traffic light states in the crossing
       // /// </summary>
       // /// <returns>array of traffic light states</returns>
       // public TrafficLight[] getState() { return null; }

        /// <summary>
        /// Add pedestrian object to the Crossing
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pathID"></param>
        public void AddPedestrianToLane(int nr, Pedestrian p)
        {
            if (crossingType == EnumSelectedCrossing.withPedestrian)
            {
                for (int i = 0; i < nr; i++)
                {
                    ListPedestrian.Add(p);
                }
            }

        }
    }
}
