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
        /// to draw path we use graphics
        /// </summary>
        Graphics gps;

        /// <summary>
        /// tpye of street
        /// </summary>
        private string typeofstreet;

        /// <summary>
        /// a list of cars in the lane
        /// </summary>
        private List<Car> cars;

        /// <summary>
        /// list of pedestrians object at the lane
        /// </summary>
        private List<Pedestrian> pedestrians;

        /// <summary>
        /// traffic light object that belongs to each path
        /// </summary>
        private TrafficLight trafficLight;

        /// <summary>
        /// 
        /// </summary>
        public int pathid;

        // ------------------------- Constructor -------------------------
        public Path(string type, Point[] p, TrafficLight tl,int pathid)
        {
            typeofstreet = type;
            points = p;            
            pedestrians = new List<Pedestrian>();
            trafficLight = tl;
            this.pathid = pathid;

            
        }

        // --------------------------- Methods ---------------------------
        public bool AddTrafficLightToPath(TrafficLight tf,int indexLane)
        {
            if (pathid == indexLane)
            {
                trafficLight = tf;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Add a new car object to the lane
        /// </summary>
        /// <param name="car">car object</param>
        /// <param name="indexLane">index of the lane</param>
        public bool AddCarToPath(Car car, int indexLane)
        {
            if (pathid == indexLane)
            {
                cars.Add(car);
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Add pedestrian object to the path
        /// </summary>
        /// <param name="p">pedestrian object to add</param>
        public bool AddPedestrianToPath(Pedestrian p)
        {
            pedestrians.Add(p);
            return true;
        }
        public bool RemoveCar(Car c)
        {
            cars.Remove(c);
            return true;
        }

        public bool RemovePedestrian(Pedestrian p)
        {
            pedestrians.Remove(p);
            return true;
        }

        
        public void ShowPath(Graphics grps,Color clr,ref int x1,ref int  y1,ref int x2,ref int y2)
        {
            Pen p = new Pen(clr);
            grps.DrawRectangle(p,x1,y1,x2,y2);
            gps.Dispose();
           
        }

        

        internal void AddCarToPath(Car c)
        {
            throw new NotImplementedException();
        }
    }
}
