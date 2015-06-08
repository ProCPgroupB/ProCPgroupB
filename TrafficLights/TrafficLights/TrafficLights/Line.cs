using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TrafficLights
{
    [Serializable]
    public class Line
    {

        // -------------------------- Attributes --------------------------
        /// <summary>
        /// a list of points that builds the paths
        /// </summary>
        private PathGeometry line;

        private int id;

        private double top;
        private double left;

        /// <summary>
        /// a list of cars in the lane
        /// </summary>
        private List<Car> laneCars;

        /// <summary>
        /// list of pedestrians object at the lane
        /// </summary>
        private List<Pedestrian> pedestrians;

        /// <summary>
        /// traffic light object that belongs to each path
        /// </summary>
        private TrafficLight trafficLight;

        // ------------------------- Constructor -------------------------
        public Line(EnumDirection dir, int id, PathGeometry line, int top, int left)
        {
            
            laneCars = new List<Car>();
            pedestrians = new List<Pedestrian>();
            this.line = line;
            this.id = id;
            this.left = left;
            this.top = top;

        }

        // --------------------------- Methods ---------------------------
        public bool AddTrafficLightToPath(TrafficLight tf)
        {
            return false;
        }

         ///<summary>
         ///Add a new car object to the lane
         ///</summary>
         ///<param name="car">car object</param>
         ///<param name="indexLane">index of the lane</param>
        public bool AddCarToPath(Car car, int indexLane)
        {
            laneCars.Add(car);
            return true;
        }
        /// <summary>
        /// Add pedestrian object to the path
        /// </summary>
        /// <param name="p">pedestrian object to add</param>
        public bool AddPedestrianToPath(Pedestrian p)
        {
            return false;
        }
        public bool RemoveCar(Car c)
        {
            return false;
        }
        public bool RemovePedestrian(Pedestrian p)
        {
            return false;
        }
        public Path ShowPath()
        {
            Path temp = new Path();
            temp.Stroke = System.Windows.Media.Brushes.Black;
            temp.StrokeThickness = 1;
            temp.Data = line;
           
            return temp;
        }

        public double Left
        {
            get { return left; }
            set { left = value; }
        }

        public double Top
        {
            get { return top; }
            set { left = value; }
        }


        // --------------------------- Animation Build-Up ---------------------------
        public PathGeometry buildPath(Point start, Point end)
        {
            PathGeometry temp = new PathGeometry();
            PathFigure tempFigure = new PathFigure();

            tempFigure.StartPoint = start;

            LineSegment ls = new LineSegment();
            ls.Point = end;

            tempFigure.Segments.Add(ls);
            temp.Figures.Add(tempFigure);

            return temp;
        }
        public DoubleAnimationUsingPath generateTranslates(string name, PathAnimationSource source, PathGeometry path, double begin, PropertyPath prop)
        {
            DoubleAnimationUsingPath temp = new DoubleAnimationUsingPath();
            temp.PathGeometry = path;
            temp.Duration = TimeSpan.FromSeconds(5);
            temp.Source = source;
            temp.BeginTime = TimeSpan.FromSeconds(begin);

            Storyboard.SetTargetName(temp, name);
            Storyboard.SetTargetProperty(temp, prop);

            return temp;
        }
        public ObjectAnimationUsingKeyFrames generateKeyframes(Rectangle r, double tick, PropertyPath part)
        {
            ObjectAnimationUsingKeyFrames temp = new ObjectAnimationUsingKeyFrames();
            temp.Duration = TimeSpan.FromSeconds(5);
            //temp.BeginTime = TimeSpan.FromSeconds(waktu);

            DiscreteObjectKeyFrame ready = new DiscreteObjectKeyFrame();
            ready.KeyTime = TimeSpan.FromSeconds(0);
            ready.Value = Visibility.Hidden;

            DiscreteObjectKeyFrame set = new DiscreteObjectKeyFrame();
            set.KeyTime = TimeSpan.FromSeconds(0.5);
            set.Value = Visibility.Visible;

            DiscreteObjectKeyFrame finish = new DiscreteObjectKeyFrame();
            finish.KeyTime = TimeSpan.FromSeconds(4 + tick);
            finish.Value = Visibility.Hidden;

            temp.KeyFrames.Add(ready);
            temp.KeyFrames.Add(set);
            temp.KeyFrames.Add(finish);

            Storyboard.SetTarget(temp, r);
            Storyboard.SetTargetProperty(temp, part);

            return temp;
        }
    
    }
}
