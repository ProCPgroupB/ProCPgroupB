using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TrafficLights
{
    class Car
    {
        // -------------------------- Attributes --------------------------

        /// <summary>
        /// Auto properties
        /// </summary>
        /// 

        private bool IsMoving { get; set; }
        private int CarWidth{get;set;}
        private int CarHeight { get; set; }
        private int IndexLane { get; set; }
        private int Speed { get; set; }
        private Brush CarColor { get; set; }
        private PointF CarCoordinates { get; set; }



        // ------------------------- Constructor -------------------------
        /// <summary>
        /// Initialization of the all the properties
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="indexlane"></param>
        /// <param name="color"></param>
        /// <param name="coordinates"></param>
        public Car(int indexlane, Brush color)
        {
            //this.CarWidth = width;
            //this.CarHeight = heught;
            //this.IndexLane = indexlane;
            //this.CarColor = color;
            //this.CarCoordinates = coordinates;
            //this.IsMoving = false;
            this.CarWidth = 4;
            this.CarHeight = 4;
            this.IndexLane = indexlane;
            this.CarColor = color;
            this.CarCoordinates = new PointF(0,0);
            this.IsMoving = false;
        }

        // --------------------------- Methods ---------------------------

        /// <summary>
        /// It will replace the old position to the new position
        /// this.X --> x; this.Y -->y
        /// </summary>
        /// <param name="loc"></param>
        public PointF SetPosition(PointF loc){
            this.CarCoordinates = loc;
            return loc;
        }

    }
}
