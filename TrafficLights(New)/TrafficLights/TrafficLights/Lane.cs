using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


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

        /// <summary>
        /// the paths point of the lane
        /// </summary>
        private Point[] lines;
        public Point[] Lines
        {
            get { return lines; }
            set { lines = value; }
        }

        private List<Pedestrian> lanePedestrians;
        public List<Pedestrian> LanePedestrians
        {
            get { return lanePedestrians; }
            set { lanePedestrians = value; }
        }

        private List<Car> laneCars;
        public List<Car> LaneCars
        {
            get { return laneCars; }
            set { laneCars = value; }
        }

        /// <summary>
        /// the capacity of cars/pedestrian of the lane
        /// </summary>
        private int laneCapacity;
        public int LaneCapacity
        {
            get { return laneCapacity; }
            set { laneCapacity = value; }
        }

        /// <summary>
        /// lane direction at the crossing
        /// </summary>
        private EnumDirection direction;
        public EnumDirection Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public bool isBlocked { get; set; }

        //------------------------Properties-------------------------------//


        private int trafficLightIndex;

        public int TrafficLightIndex
        {
            get { return trafficLightIndex; }
            set { trafficLightIndex = value; }
        }

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of the lane
        /// </summary>
        /// <param name="paths">paths point of the lane</param>
        /// <param name="id">traffic light id, that belongs to the lane</param>
        public Lane(EnumDirection dir, Point[] lines, int trafficLightID)
        {
            this.direction = dir;
            this.lines = lines;
            this.trafficLightIndex = trafficLightID;
            this.laneCapacity = 25;

            this.laneCars = new List<Car>();
            this.lanePedestrians = new List<Pedestrian>();

            isBlocked = false;
        }
        // --------------------------- Methods ---------------------------

        
        /// <summary>
        /// Add car object to the lane
        /// </summary>
        /// <param name="c"></param>
        /// <param name="lane_ID"></param>
        public void AddCarToLane(Car c, int indexLane)
        {
            c.TotalDots = this.Lines.Count();
            c.NextDots = 1;
            c.CarCoordinates = new PointF(this.Lines[0].X, this.Lines[0].Y);
            c.LaneIndex = indexLane;
            laneCars.Add(c);
        }

        /// <summary>
        /// Add pedestrian object to the lane
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pathID"></param>
        public void AddPedestrianToLane(Pedestrian p)
        {
            p.TotalDots = this.Lines.Count();
            p.NextDots = 1;
            p.PedestrianCoordinates = new PointF(this.Lines[0].X, this.Lines[0].Y);
            lanePedestrians.Add(p);
        }

        /// <summary>
        /// Remove car object from the lane
        /// </summary>
        /// <param name="c"></param>
        /// <param name="pathID"></param>
        /// <returns></returns>
        public bool RemoveCarFromLane(int id)
        {
            laneCars.RemoveAt(id);
            return true;
        }

        /// <summary>
        /// Remove pedestrian from the lane
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pathID"></param>
        /// <returns></returns>
        public bool RemovePedestrianFromLane(string p, int pathID)
        {
            return false;
        }
         

        
    }
}
