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
    /// 
    /// </summary>
    class WithPedestrian : Crossing
    {

        // -------------------------- Properties --------------------------

        /// <summary>
        /// a list of pedestrians inside the crossing
        /// </summary>
        private Pedestrian[] pedestrians;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of WithPedestrian
        /// </summary>
        /// <param name="type">type of the crossing</param>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        public WithPedestrian(EnumSelectedCrossing type, int row, int col)
            : base(type, row, col)
        {

        }

        // --------------------------- Methods ---------------------------

        /// <summary>
        /// 
        /// </summary>
        public void GenerateLane()
        {

        }

        /// <summary>
        /// get traffic light states in the crossing
        /// </summary>
        /// <returns>array of traffic light states</returns>
       // public override TrafficLight[] getState() { return null; }


        /// <summary>
        /// add a new pedestrian to the crossing based on the lane position in the crossing
        /// </summary>
        /// <param name="p"></param>
        /// <param name="indexLane "></param>
        //public bool AddPedestrian(Pedestrian p, int indexLane)
        //{
        //}

    }
}
