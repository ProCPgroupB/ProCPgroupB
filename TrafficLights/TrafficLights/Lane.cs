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
        private List<Path> paths;

        /// <summary>
        /// the capacity of cars/pedestrian of the lane
        /// </summary>
        private int capacity;

        /// <summary>
        /// lane direction at the crossing
        /// </summary>
        private EnumDirection direction;

        
       

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
        }

        // --------------------------- Methods ---------------------------

        /// <summary>
        /// Generate a list of path that belongs in the lane
        /// </summary>
        public void GeneretaPath()
        {
            paths = new List<Path>();
           
        }

        /// <summary>
        /// Add car object to the lane
        /// </summary>
        /// <param name="c"></param>
        /// <param name="pathID"></param>
        public void AddCarToLane(Car c, int pathID)
        {
            foreach (Path mypath in paths)
            {
                if (mypath.pathid == pathID)
                {
                    mypath.AddCarToPath(c);
                   
                }
            }
           
           

        }

        /// <summary>
        /// Add pedestrian object to the lane
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pathID"></param>
        public void AddPedestrianToLane(Pedestrian p, int pathID)
        {
            foreach (Path mypath in paths)
            {
                if (mypath.pathid == pathID)
                {
                    mypath.AddPedestrianToPath(p);
                }
            }
        }

        /// <summary>
        /// Remove car object from the lane
        /// </summary>
        /// <param name="c"></param>
        /// <param name="pathID"></param>
        /// <returns></returns>
        public bool RemoveCarFromLane(Car c, int pathID)
        {
            foreach (Path mypath in paths)
            {
                if (mypath.pathid == pathID)
                {
                    mypath.RemoveCar(c);
                    return true;
                }
            }
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
            foreach (Path mypath in paths)
            {
                if (mypath.pathid == pathID)
                {
                    mypath.RemovePedestrian(p);
                    return true;
                }               
                  
            }
            return false;
        }
    }
}
