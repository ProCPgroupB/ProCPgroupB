using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace TrafficLights
{
    [Serializable]
    public class TrafficControl
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
            crossingList = new Crossing[3, 5];
        }

        // --------------------------- Methods ---------------------------

        public String Number2String(int number, bool isCaps)
        {
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            return c.ToString();
        }

        /// <summary>
        /// Add Crossing object to crossingList at certain index location
        /// </summary>
        /// <param name="type">type of the crossing</param>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        public bool AddCrossing(string type, int row, int col)
        {
            // ID = COLROW, ex A1
            string id = Number2String((col+1), true) + (row+1).ToString();


            if (type == EnumSelectedCrossing.withoutPedestrian.ToString())
            {
                crossingList[row, col] = new WithoutPedestrian(EnumSelectedCrossing.withoutPedestrian, row, col);
                return true;
            }
            else if (type == EnumSelectedCrossing.withPedestrian.ToString())
            {
                crossingList[row, col] = new WithPedestrian(EnumSelectedCrossing.withPedestrian, row, col);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Remove Crossing object from crossingList at certain index location
        /// </summary>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        public bool RemoveCrossing(int row, int col) {
            if (crossingList[row, col] != null)
            {
                crossingList[row, col] = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAll()
        {
            Array.Clear(crossingList, 0, crossingList.Length);
        }

        /// <summary>
        /// Get crossing at defined position(row and column) at the grid
        /// from the crossingList
        /// </summary>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        /// <returns>Crossing Object</returns>
        public Crossing GetCrossing(int row, int col) {

            try
            {
                return crossingList[row, col];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Get All Crossings
        /// </summary>
        /// <returns>crossingList</returns>
        public Crossing[,] GetAllCrossing
        {
            get { return crossingList; }
            set { crossingList = value; }
        }

        public bool[] GetConnection(Point currentCrossing)
        {
            bool[] connections = new bool[] { false, false, false, false };
            // top
            if (GetCrossing(currentCrossing.X - 1, currentCrossing.Y) != null)
            {
                connections[0] = true;
            }
            // right
            if (GetCrossing(currentCrossing.X, currentCrossing.Y + 1) != null)
            {
                connections[1] = true;
            }
            // down
            if (GetCrossing(currentCrossing.X + 1, currentCrossing.Y) != null)
            {
                connections[2] = true;
            }
            // left
            if (GetCrossing(currentCrossing.X, currentCrossing.Y - 1) != null)
            {
                connections[3] = true;
            }
            return connections;
        }

        public float CalculateAngle(Point first, Point second)
        {
            float dX = second.X - first.X;
            float dY = second.Y - first.Y;
            double angle = Math.Atan2(dY, dX) * 180 / Math.PI;
            return (float)angle;
        }

        public PointF MoveObject(PointF start, double distance, double angle)
        {
            double rad = Math.PI * angle / 180.0;
            PointF newPoint = new Point(0, 0);
            newPoint.X = (float)(start.X + (distance * Math.Cos(rad)));
            newPoint.Y = (float)(start.Y + (distance * Math.Sin(rad)));
            return newPoint;
        }

        public bool toNextCrossing(Car car, Crossing c)
        {
            // North
            if (car.GetCarObject().Y - 10 < 0 && GetConnection(c.CrossingPosition)[(int)EnumDirection.North])
            {
                return GetCrossing(c.CrossingPosition.X - 1, c.CrossingPosition.Y).AddCarToLane(EnumDirection.South, new Car(0));
            }
            // East
            else if (car.GetCarObject().X + 10 > 200 && GetConnection(c.CrossingPosition)[(int)EnumDirection.East])
            {
                return GetCrossing(c.CrossingPosition.X, c.CrossingPosition.Y + 1).AddCarToLane(EnumDirection.West, new Car(0));
            }
            // South
            else if (car.GetCarObject().Y + 20 > 200 && GetConnection(c.CrossingPosition)[(int)EnumDirection.South])
            {
                return GetCrossing(c.CrossingPosition.X + 1, c.CrossingPosition.Y).AddCarToLane(EnumDirection.North, new Car(0));
            }
            // West
            else if (car.GetCarObject().X - 10 < 0 && GetConnection(c.CrossingPosition)[(int)EnumDirection.West])
            {
                return GetCrossing(c.CrossingPosition.X, c.CrossingPosition.Y - 1).AddCarToLane(EnumDirection.East, new Car(0));

            }
            return true;
        }

        /// <summary>
        /// will rotate the map
        /// </summary>
        public void RotateCrossing() { }



    }
}
