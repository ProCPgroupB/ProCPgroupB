using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TrafficLights
{
    class TrafficControl
    {
        // -------------------------- Attributes --------------------------

        /// <summary>
        /// a list of multi-dimensional array for crossing objects
        /// </summary>
        private Crossing[,] crossingList;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of Traffic Control
        /// </summary>
        public TrafficControl()
        {
            crossingList = new Crossing[4, 4];
        }

        // --------------------------- Methods ---------------------------

        /// <summary>
        /// Add Crossing object to crossingList at certain index location
        /// </summary>
        /// <param name="type">type of the crossing</param>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        public bool AddCrossing(int type, int row, int col) { return false; }
        
        /// <summary>
        /// Remove Crossing object from crossingList at certain index location
        /// </summary>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        public bool RemoveCrossing(int row, int col) { return false; }
        
        /// <summary>
        /// Get crossing at defined position(row and column) at the grid
        /// from the crossingList
        /// </summary>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        /// <returns>Crossing Object</returns>
        public Crossing GetCrossing(int row, int col) { return null; }

        /// <summary>
        /// Get crossing at defined position(point) at the grid
        /// from the crossingList
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>Crossing Object</returns>
        public Crossing GetCrossing(Point pos) { return null; }

        /// <summary>
        /// will rotate the map
        /// </summary>
        public void RotateCrossing() { }



    }
}
