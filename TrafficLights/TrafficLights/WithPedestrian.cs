using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights
{
    class WithPedestrian : Crossing
    {

        // Properties

        // Constructor
        public WithPedestrian(int type, int row, int col) : base(type, row, col)
        {

        }
        // Methods
        public override TrafficLight[] getState() { return null; }
    }
}
