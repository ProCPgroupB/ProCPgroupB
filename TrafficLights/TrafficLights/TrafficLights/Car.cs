using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrafficLights
{
    [Serializable]
    public class Car
    {
        // -------------------------- Attributes --------------------------

        private static int width = 10;
        private static int height = 10;
        private Brush color;
        private Brush stroke;
        private static int strokeThickness = 2;
        private string name;
        //private PointF coor;
        private int p1;
        private string p2;
        private int x = 0;
        private int y = 0;

        // ------------------------- Constructor -------------------------
        /// <summary>
        /// Initialization of the all the properties
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="indexlane"></param>
        /// <param name="color"></param>
        /// <param name="coordinates"></param>
        public Car(int indexPath, string name, Brush color, Brush stroke)
        {
            this.name = name;
            this.color = color;
            this.stroke = stroke;
            //this.coor = pos;
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


        public Rectangle ShowCar(int path)
        {
            Rectangle r = new Rectangle();

            return r;
        }

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

    }
}
