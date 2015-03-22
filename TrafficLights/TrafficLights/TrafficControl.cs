using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights
{
    class TrafficControl
    {
        // Properties
        private Crossing[,] crossingList;

        // Constructor
        public TrafficControl()
        {

        }

        // Methods
        public void AddCrossing(int type, int row, int col) { }
        public void RemoveCrossing(int row, int col) { }
        public Crossing GetCrossing(int row, int col) { return null; }
    }
}
