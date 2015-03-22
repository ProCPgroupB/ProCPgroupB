using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TrafficLights
{
    class Crossing 
    {
        // Properties
        private int crossroadType;
        private Point crossroadPosition;

        // Constructor
        public Crossing(int type, int row, int col)
        {
            crossroadType = type;
            crossroadPosition = new Point(row, col);
        }

        // Methods
        public void AddCar(EnumLaneDirection direction, Car c)
        {

        }

        public void AddPedestrian(Pedestrian p, int laneIndex){
        }

        public void ChangeCase(){}

        public TrafficLight[] getState() { }
    }
}
