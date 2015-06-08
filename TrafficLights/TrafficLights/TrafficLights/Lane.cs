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
    /// <summary>
    /// this class create lane object. Lane is a part of crossing that have its own 
    /// traffic lights, car stream, and pedestrian stream. 
    /// </summary>
    public class Lane
    {
        // -------------------------- Attributes -------------------------

        public List<Car> ListCar;

        /// <summary>
        /// the paths point of the lane
        /// </summary>
        private List<Line> paths;

        /// <summary>
        /// the capacity of cars/pedestrian of the lane
        /// </summary>
        private int capacity;

        /// <summary>
        /// lane direction at the crossing
        /// </summary>
        private EnumDirection direction;

        //------------------------Properties-------------------------------//

        public int Lane_ID { get; set; }

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of the lane
        /// </summary>
        /// <param name="paths">paths point of the lane</param>
        /// <param name="id">traffic light id, that belongs to the lane</param>
        public Lane(EnumDirection dir, int capacity, int top, int left)
        {
            direction = dir;
            this.capacity = capacity;
            this.ListCar = new List<Car>(5);
            this.paths = new List<Line>();
            this.GeneretaPath(top, left);
        }

        // --------------------------- Methods ---------------------------

        /// <summary>
        /// Generate a list of path that belongs in the lane
        /// </summary>
        public void GeneretaPath(int top, int left)
        {
            // EnumDirection.East
            // Out Path

            StringToPathGeometryConverter convertPath = new StringToPathGeometryConverter();
            PathGeometry P1 = new PathGeometry(); ;
            PathGeometry P2 = new PathGeometry(); ;
            PathGeometry P3 = new PathGeometry(); ;
            PathGeometry P4 = new PathGeometry(); ;

           

            if (direction == EnumDirection.North)
            {
                P1 = convertPath.Convert("M79.333333,0 L79.333333,46.833333");
                P2 = convertPath.Convert("M90,0.66666667 L100.16667,20.499667 100.49932,48.499666");
                P3 = convertPath.Convert("M123,64.333333 L123,0.16700254");
                P4 = convertPath.Convert("M123.167,63.833673 L122.58365,18.08401 112.167,-0.49918851");
                
            }
            else if (direction == EnumDirection.East)
            {
                P1 = convertPath.Convert("M200,78.333333 L152.16667,78.333333");
                P2 = convertPath.Convert("M199.66667,88.333333 L178.49967,99.833669 148.16632,99.833669");
                P3 = convertPath.Convert("M134.33333,121.66667 L198.16699,121.66667 134.167,121.49966 180.49999,121.49966");
                P4 = convertPath.Convert("M123.167,63.833673 L122.58365,18.08401 112.167,-0.49918851");
            }
            else if (direction == EnumDirection.West)
            {
                P1 = convertPath.Convert("M-0.66666667,121.66667 L50.500333,121.66667");
                P2 = convertPath.Convert("M-0.33333333,111.33333 L20.499667,101.167 50.499666,100.83332");
                P3 = convertPath.Convert("M63.333333,78.333333 L0.16699873,78.333333");
                P4 = convertPath.Convert("M63.666667,78.666667 L17.833001,78.666667 -0.16653335,88.166331");
            }
            else
            {
                P1 = convertPath.Convert("M123.33333,200.33333 L123.08233,150.91599");
                P2 = convertPath.Convert("M113,200 L101.83333,177.83333 101.83333,148.50076");
                P3 = convertPath.Convert("M79,134.33333 L78.5,198.16699");
                P4 = convertPath.Convert("M79,135 L79,179.16667 89.5,199.83285");
            }
            // In1
            Line in1 = new Line(direction, 1, P1, top, left);
            // In2
            Line in2 = new Line(direction, 2, P2, top, left);
            // Out1
            Line out1 = new Line(direction, 3, P3, top, left);
            // Out2
            Line out2 = new Line(direction, 4, P4, top, left);

            paths.Add(in1);
            paths.Add(in2);
            paths.Add(out1);
            paths.Add(out2);


        }

        /// <summary>
        /// Add car object to the lane
        /// </summary>
        /// <param name="c"></param>
        /// <param name="lane_ID"></param>
        public void AddCarToLane(int nr)
        {
            Brush fill = new SolidColorBrush(Colors.LightSteelBlue);
            Brush stroke = new SolidColorBrush(Colors.White);

            for (int i = 0; i < nr; i++)
            {
                ListCar.Add(new Car(1, "Car", fill, stroke));
            }
        }

        /// <summary>
        /// Add pedestrian object to the lane
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pathID"></param>
        //public void AddPedestrianToLane(int nr)
        //{

        //}

        /// <summary>
        /// Remove car object from the lane
        /// </summary>
        /// <param name="c"></param>
        /// <param name="pathID"></param>
        /// <returns></returns>
        public bool RemoveCarFromLane(Car c, int pathID)
        {

            return false;
        }

        /// <summary>
        /// Remove pedestrian from the lane
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pathID"></param>
        /// <returns></returns>
        public bool RemovePedestrianFromLane(Pedestrian p, int pathID)
        {
            return false;
        }

        public List<Line> Paths
        {
            get { return paths; }
            set { paths = value; }
        }
    }
}
