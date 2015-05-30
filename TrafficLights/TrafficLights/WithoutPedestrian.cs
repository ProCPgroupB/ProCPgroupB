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
    /// 
    /// </summary>
    class WithoutPedestrian : Crossing
    {

        // ------------------------- Constructor -------------------------
        /// <summary>
        /// Constructor of WithoutPedestrian
        /// </summary>
        /// <param name="type">type of the crossing</param>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        public WithoutPedestrian(EnumSelectedCrossing type, int row, int col, string id)
            : base(type, row, col, id)
        {

        }

        // --------------------------- Methods ---------------------------


        public void GenerateLane()
        {

        }


        /// <summary>
        /// get traffic light states in the crossing
        /// </summary>
        /// <returns>array of traffic light states</returns>
        //public override TrafficLight[] getState() { return null; }
    }
}
