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
       /******************************** Properties**************************************************/

        /// <summary>
        /// Auto properties
        /// </summary>
        /// 

        private bool IsMoving { get; set; }

        private int CarWidth{get;set;}
        private int CarHeight { get; set; }
        private int IndexLane { get; set; }
        private Brush CarColor { get; set; }
        private PointF CarCoordinates { get; set; }



        /**********************************Constructor of the car class********************************/
        /// <summary>
        /// Initialization of the all the properties
        /// </summary>
        /// <param name="width"></param>
        /// <param name="heught"></param>
        /// <param name="indexlane"></param>
        /// <param name="color"></param>
        /// <param name="coordinates"></param>
        public Car(int width,int heught,int indexlane,Brush color,PointF coordinates)
        {
            this.CarWidth = width;
            this.CarHeight = heught;
            this.IndexLane = indexlane;
            this.CarColor = color;
            this.CarCoordinates = coordinates;
            this.IsMoving = false;
        }


        /******************************************* Methods*********************************************/

        /// <summary>
        /// It will replace the old position to the new position
        /// this.X --> x; this.Y -->y
        /// </summary>
        /// <param name="loc"></param>
        public PointF SetPos(PointF loc){
            this.CarCoordinates = loc;
            return loc;
        }

    }
}
