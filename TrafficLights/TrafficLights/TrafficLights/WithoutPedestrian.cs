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

            GenerateLane(row, col);
        }

        // --------------------------- Methods ---------------------------


        public override void GenerateLane(int top, int left)
        {
            Lane East = new Lane(EnumDirection.East, 5, top, left);
            Lane West = new Lane(EnumDirection.West, 5, top, left);
            Lane North = new Lane(EnumDirection.North, 5, top, left);
            Lane South = new Lane(EnumDirection.South, 5, top, left);

            base.Lanes.Add(East);
            base.Lanes.Add(West);
            base.Lanes.Add(North);
            base.Lanes.Add(South);
        }


        /// <summary>
        /// get traffic light states in the crossing
        /// </summary>
        /// <returns>array of traffic light states</returns>
        //public override TrafficLight[] getState() { return null; }
    }
}
