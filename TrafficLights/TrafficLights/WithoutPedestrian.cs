using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights
{
    class WithoutPedestrian : Crossing
    {

        // Properties

        // Constructor
        public WithoutPedestrian(int type, int row, int col)
            : base(type, row, col)
        {

        }
        // Methods
        public override TrafficLight[] getState() { return null; }
    }
}
