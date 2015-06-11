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
    public class Car
    {
        // -------------------------- Attributes --------------------------
        public static int CarWidth = 8;
        public static int CarHeight = 4;

        private int laneIndex;
        public int LaneIndex
        {
            get { return laneIndex; }
            set { laneIndex = value; }
        }

        private int nextDots;
        public int NextDots
        {
            get { return nextDots; }
            set { nextDots = value; }
        }

        private int totalDots;
        public int TotalDots
        {
            get { return totalDots; }
            set { totalDots = value; }
        }

        private Brush carColor;
        public Brush CarColor
        {
            get { return carColor; }
            set { carColor = value; }
        }

        private PointF carCoordinates;
        public PointF CarCoordinates
        {
            get { return carCoordinates; }
            set { carCoordinates.X = value.X; carCoordinates.Y = value.Y; carCoordinates = value; }
        }

        private RectangleF carObject;
        public RectangleF CarObject
        {
            get { return carObject; }
            set { carObject = value; }
        }

        private Matrix rotateCar;
        public Matrix RotateCar
        {
            get { return rotateCar; }
            set { rotateCar = value; }
        }

        // ------------------------- Constructor -------------------------
        /// <summary>
        /// Car Constructor
        /// </summary>
        /// <param name="indexPath"></param>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="stroke"></param>
        public Car(int laneId)
        {
            this.laneIndex = laneId;
            this.CarColor = Brushes.DarkBlue;
            this.nextDots = 1;
            this.carCoordinates = new PointF(0, 0);

            rotateCar = new Matrix();

            this.carObject.X = CarCoordinates.X;
            this.carObject.Y = CarCoordinates.Y;
            this.carObject.Height = CarHeight;
            this.carObject.Width = CarWidth;
        }

        // --------------------------- Methods ---------------------------

        /// <summary>
        /// It will replace the old position to the new position
        /// this.X --> x; this.Y -->y
        /// </summary>
        /// <param name="loc"></param>
        //public PointF SetPosition(PointF loc){
        //    this.CarCoordinates = loc;
        //    return loc;
        //}
        public RectangleF GetCarObject()
        {
            RectangleF temp = new RectangleF(carObject.X - CarHeight / 2, carObject.Y - CarWidth / 2, CarHeight, CarWidth);
            return temp;
        }

        
    }
}
