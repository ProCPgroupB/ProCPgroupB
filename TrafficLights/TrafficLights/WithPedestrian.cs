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
    /// WithPedestrian Class inherits Crossing Class but 
    /// </summary>
    class WithPedestrian : Crossing
    {

        // -------------------------- Properties --------------------------

        // <summary>
        /// two dimensional array of path points of the crossing
        /// </summary>
        Point[][] pathsOfCrossing;



        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of WithPedestrian
        /// </summary>
        /// <param name="type">type of the crossing</param>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        public WithPedestrian(int type, int row, int col) : base(type, row, col)
        {

        }

        // --------------------------- Methods ---------------------------

        /// <summary>
        /// get traffic light states in the crossing
        /// </summary>
        /// <returns>array of traffic light states</returns>
        public override TrafficLight[] getState() { return null; }

    }
}
