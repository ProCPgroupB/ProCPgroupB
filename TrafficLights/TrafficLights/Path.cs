using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TrafficLights
{
    class Path
    {

        // -------------------------- Attributes --------------------------
        /// <summary>
        /// a list of points that builds the paths
        /// </summary>
        private Point[] points;

        /// <summary>
        /// a list of cars in the lane
        /// </summary>
        private List<Car> laneCars;

        /// <summary>
        /// list of pedestrians object at the lane
        /// </summary>
        private List<Pedestrian> pedestrians;

        /// <summary>
        /// traffic light object that belongs to each path
        /// </summary>
        private TrafficLight trafficLight;

        // ------------------------- Constructor -------------------------
        public Path(string type, Point[] p, TrafficLight tl)
        {
            points = p;
            laneCars = new List<Car>();
            pedestrians = new List<Pedestrian>();
            trafficLight = tl;
        }

        // --------------------------- Methods ---------------------------
        public bool AddTrafficLightToPath(TrafficLight tf)
        {
            return false;
        }

        /// <summary>
        /// Add a new car object to the lane
        /// </summary>
        /// <param name="car">car object</param>
        /// <param name="indexLane">index of the lane</param>
        //public bool AddCarToPath(Car car, int indexLane)
        //{
            
        //}
        /// <summary>
        /// Add pedestrian object to the path
        /// </summary>
        /// <param name="p">pedestrian object to add</param>
        public bool AddPedestrianToPath(Pedestrian p)
        {
            return false;
        }
        public bool RemoveCar(Car c)
        {
            return false;
        }
        public bool RemovePedestrian(Pedestrian p)
        {
            return false;
        }
        public void ShowPath()
        {

        }

    }
}
