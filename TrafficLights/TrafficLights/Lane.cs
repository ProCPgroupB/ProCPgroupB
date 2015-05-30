using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TrafficLights
{
    [Serializable]
    /// <summary>
    /// this class create lane object. Lane is a part of crossing that have its own 
    /// traffic lights, car stream, and pedestrian stream. 
    /// </summary>
    public class Lane
    {
        // -------------------------- Attributes -------------------------

        public List<Car> ListCar;


        /// <summary>
        /// the paths point of the lane
        /// </summary>
        private List<Path> paths;

        //public int GetNumberOfCars()
        //{
        //    foreach (Car c in ListOfCars)
        //    {
                
        //    }
        //}

        /// <summary>
        /// the capacity of cars/pedestrian of the lane
        /// </summary>
        private int capacity;

        /// <summary>
        /// lane direction at the crossing
        /// </summary>
        private EnumDirection direction;

        //------------------------Properties-------------------------------//

        public int Lane_ID { get; set; }

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of the lane
        /// </summary>
        /// <param name="paths">paths point of the lane</param>
        /// <param name="id">traffic light id, that belongs to the lane</param>
        public Lane(EnumDirection dir, int capacity)
        {
            direction = dir;
            this.capacity = capacity;
            this.ListCar = new List<Car>(5);
        }

        // --------------------------- Methods ---------------------------

        /// <summary>
        /// Generate a list of path that belongs in the lane
        /// </summary>
        public void GeneretaPath()
        {

        }

        /// <summary>
        /// Add car object to the lane
        /// </summary>
        /// <param name="c"></param>
        /// <param name="lane_ID"></param>
        public void AddCarToLane(int nr)
        {
            for (int i = 0; i < nr; i++)
            {
                ListCar.Add(new Car(this.Lane_ID));
            }
        }

        /// <summary>
        /// Add pedestrian object to the lane
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pathID"></param>
        //public void AddPedestrianToLane(int nr)
        //{

        //}

        /// <summary>
        /// Remove car object from the lane
        /// </summary>
        /// <param name="c"></param>
        /// <param name="pathID"></param>
        /// <returns></returns>
        public bool RemoveCarFromLane(Car c, int pathID)
        {
            return false;
        }

        /// <summary>
        /// Remove pedestrian from the lane
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pathID"></param>
        /// <returns></returns>
        public bool RemovePedestrianFromLane(Pedestrian p, int pathID)
        {
            return false;
        }
    }
}
