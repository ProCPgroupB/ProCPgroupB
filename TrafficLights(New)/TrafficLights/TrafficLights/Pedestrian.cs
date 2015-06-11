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
    public class Pedestrian
    {
        // -------------------------- Attributes --------------------------
        public bool IsMoving { get; set; }

        private static int PedestrianWidth = 4;
        private static int PedestrianHeight = 4;

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

        private Brush pedestrianColor;
        public Brush PedestrianColor
        {
            get { return pedestrianColor; }
            set { pedestrianColor = value; }
        }

        private PointF pedestrianCoordinates;
        public PointF PedestrianCoordinates
        {
            get { return pedestrianCoordinates; }
            set { pedestrianObject.X = value.X; pedestrianObject.Y = value.Y; pedestrianCoordinates = value; }
        }

        private RectangleF pedestrianObject;
        public RectangleF PedestrianObject
        {
            get { return pedestrianObject; }
            set { pedestrianObject = value; }
        }

        // ------------------------- Constructor -------------------------
        /// <summary>
        /// Initialization of all the properties
        /// </summary>
        /// <param name="widht"></param>
        /// <param name="height"></param>
        /// <param name="indexlane"></param>
        /// <param name="color"></param>
        /// <param name="coordinates"></param>
        public Pedestrian(int laneId)
        {
            this.laneIndex = laneId;
            this.nextDots = 1;

            this.PedestrianColor = Brushes.ForestGreen;

            this.pedestrianCoordinates = new PointF(0,0);

            this.pedestrianObject.X = pedestrianCoordinates.X;
            this.pedestrianObject.Y = pedestrianCoordinates.Y;
            this.pedestrianObject.Height = PedestrianHeight;
            this.pedestrianObject.Width = PedestrianWidth;

            this.IsMoving = false;
        }

        // --------------------------- Methods ---------------------------
        /// <summary>
        /// Set Position will replace the old location by the new location
        /// this.X --> x
        /// this.Y --> y
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public void SetPosition(PointF loc)
        {
            this.PedestrianCoordinates = loc;

          
        }

        public RectangleF GetPedestrianObject()
        {
            RectangleF temp = new RectangleF(PedestrianCoordinates.X - PedestrianHeight / 2, PedestrianCoordinates.Y - PedestrianWidth / 2, PedestrianWidth + 2, PedestrianHeight + 2);
            return temp;
        }
    }
}
