using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TrafficLights
{
    class Pedestrian
    {
        // -------------------------- Attributes --------------------------
        /// <summary>
        /// Auto properties
        /// </summary>
        /// 

        public bool IsMoving { get; set; }
        private int PedestrianWidth { get; set; }
        private int PedestrianHeight{get; set; }
        private int IndexLane { get; set; }
        private Brush PedestrianColor { get; set; }
        private PointF PedestrianCoordinates { get; set; }

        // ------------------------- Constructor -------------------------
        /// <summary>
        /// Initialization of all the properties
        /// </summary>
        /// <param name="widht"></param>
        /// <param name="height"></param>
        /// <param name="indexlane"></param>
        /// <param name="color"></param>
        /// <param name="coordinates"></param>
        public Pedestrian(int widht,int height,int indexlane,Brush color,PointF coordinates)
        {
            this.PedestrianWidth = widht;
            this.PedestrianHeight = height;
            this.IndexLane = indexlane;
            this.PedestrianColor = color;
            this.PedestrianCoordinates = coordinates;
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
        public PointF SetPosition(PointF loc)
        {
            this.PedestrianCoordinates = loc;
            return loc;
        }

    }
}
