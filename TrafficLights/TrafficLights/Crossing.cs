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
        // -------------------------- Properties --------------------------

        /// <summary>
        /// type of the crossing
        /// </summary>
        private int crossingType;

        /// <summary>
        /// position of the crossing
        /// </summary>
        private Point crossingPosition;

        /// <summary>
        /// a list of cars inside the crossing
        /// </summary>
        private Car[] cars;

        /// <summary>
        /// a list of pedestrians inside the crossing
        /// </summary>
        private Pedestrian[] pedestrians;

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
        public Crossing(int type, int row, int col)
        {
            crossingType = type;
            crossingPosition = new Point(row, col);
        }

        // --------------------------- Methods ---------------------------

        /// <summary>
        /// add a new car to the crossing based on the lane direction
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="c"></param>
        public void AddCar(EnumLaneDirection direction, Car c)
        {

        }

        /// <summary>
        /// add a new pedestrian to the crossing based on the lane position in the crossing
        /// </summary>
        /// <param name="p"></param>
        /// <param name="laneIndex"></param>
        public void AddPedestrian(Pedestrian p, int laneIndex){
        }

        /// <summary>
        /// change crossing case based on time in the simulation
        /// </summary>
        public void ChangeCase(int time){}

        /// <summary>
        /// get traffic light states in the crossing
        /// </summary>
        /// <returns>array of traffic light states</returns>
        public TrafficLight[] getState() { return null; }
    }
}
