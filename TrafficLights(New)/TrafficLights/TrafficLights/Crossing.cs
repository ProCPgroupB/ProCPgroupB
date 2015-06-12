using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace TrafficLights
{
    [Serializable]
    /// <summary>
    /// This class create a crossing object. 
    /// </summary>
    public class Crossing
    {
        // -------------------------- Attributes --------------------------

        private TrafficLight[] trafficLightsList;
        public TrafficLight[] TrafficLightsList
        {
            get { return trafficLightsList; }
            set { trafficLightsList = value; }
        }

        public List<Lane> CrossingLane;

        /// <summary>
        /// type of the crossing // change to enum to determine the crossing
        /// </summary>
        // private int crossingType;
        private EnumSelectedCrossing crossingType;
        public EnumSelectedCrossing CrossingType
        {
            get { return crossingType; }
            set { crossingType = value; }
        }

        /// <summary>
        /// position of the crossing
        /// </summary>
        private Point crossingPosition;
        public Point CrossingPosition
        {
            get { return crossingPosition; }
            set { crossingPosition = value; }
        }


        /// <summary>
        /// current case that working in the crossing
        /// </summary>
        public EnumCase CurrentCase
        {
            get;
            set;
        }

        /// <summary>
        /// List of duration for each cases.
        /// </summary>
        public int[] CaseDurations
        {
            get;
            set;
        }

        /// <summary>
        /// a property to define crossing is a source of car/pedestrian or not
        /// </summary>
        private bool isSource;
        public bool IsSource
        {
            get { return isSource; }
            set
            {
                isSource = value;
            }
        }

        public int tempCaseDuration
        {
            get;
            set;
        }

        public int NorthCars { get; set; }
        public int EastCars { get; set; }
        public int SouthCars { get; set; }
        public int WestCars { get; set; }

        Random r = new Random();

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of the crossing
        /// </summary>
        /// <param name="type">type of the crossing</param>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        public Crossing(EnumSelectedCrossing type, int row, int col)
        {
            this.crossingType = type;
            this.crossingPosition = new Point(row, col);
            this.CurrentCase = EnumCase.caseAGreen;
            this.isSource = checkSource(row, col);
            this.CaseDurations = new int[(int)EnumCase.caseDYellow + 1];
            
            tempCaseDuration = 0;

            generateCars();
        }

        // --------------------------- Methods ---------------------------

        public bool checkSource(int row, int col)
        {
            bool temp;
            if (row == 0)
            {
                temp = true;
            }
            else if (row == 1)
            {
                if (col == 0 || col == 4)
                {
                    temp = true;
                }
                else
                {
                    temp = false;
                }
            }
            else if (row == 2)
            {
                temp = true;
            }
            else
            {
                temp = false;
            }
            return temp;
        }

        public void generateCars()
        {
            NorthCars = 0;
            EastCars = 0;
            SouthCars = 0;
            WestCars = 0;


            switch (crossingPosition.X)
            {
                case 0:
                    NorthCars = 5;
                    switch (crossingPosition.Y)
                    {
                        case 0:
                            WestCars = 5;
                            break;
                        case 4:
                            EastCars = 5;
                            break;
                    }
                    break;
                case 1:
                    switch (crossingPosition.Y)
                    {
                        case 0:
                            WestCars = 5;
                            break;
                        case 4:
                            EastCars = 5;
                            break;
                    }
                    break;
                case 2:
                    SouthCars = 5;
                    switch (crossingPosition.Y)
                    {
                        case 0:
                            WestCars = 5;
                            break;
                        case 4:
                            EastCars = 5;
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// add a new car to the crossing based on the lane direction
        /// </summary>
        /// <param name="direction">Crossing direction</param>
        /// <param name="c">Car object</param>
        public bool AddCarToLane(EnumDirection direction, Car c)
        {
            bool carOk = true;
            List<Lane> temp = GetLanes(direction);
            foreach (Lane l in temp)
            {
                if (l.LaneCars.Count() > 0)
                {
                    RectangleF lastCar = l.LaneCars.Last().GetCarObject();

                    float x = l.Lines[0].X - lastCar.Width / 2;
                    float y = l.Lines[0].Y - lastCar.Height / 2;

                    RectangleF newCar = new RectangleF(x,y,lastCar.Width, lastCar.Height);

                    if (lastCar.IntersectsWith(newCar))
                    {
                        carOk = false;
                        return false;
                    }
                }
            }
           

            int laneNr = 0;
            int indexof = 0;

            laneNr = r.Next(0, 3);

            if (direction == EnumDirection.East)
            {
                indexof = laneNr + 3;
            }
            else if (direction == EnumDirection.South)
            {
                indexof = laneNr +  6;
            }
            else if (direction == EnumDirection.West)
            {
                indexof = laneNr +  9;
            }


            if (carOk)
            {
                temp[laneNr].AddCarToLane(c, indexof);
                return true;
            }
            return false;
        }

        /// <summary>
        ///  change crossing case based on time in the simulation
        /// </summary>
        /// <param name="time">timer</param>
        public void ChangeCase(int time) 
        {
            tempCaseDuration += time;

            switch (CurrentCase)
            {
                case EnumCase.caseAGreen:
                    if(tempCaseDuration == CaseDurations[(int)EnumCase.caseAGreen]){
                        CurrentCase = EnumCase.caseAYellow;
                        tempCaseDuration = 0;
                    }
                    break;
                case EnumCase.caseAYellow:
                    if(tempCaseDuration == CaseDurations[(int)EnumCase.caseAYellow]){
                        CurrentCase = EnumCase.caseBGreen;
                        tempCaseDuration = 0;
                    }
                    break;
                case EnumCase.caseBGreen:
                    if(tempCaseDuration == CaseDurations[(int)EnumCase.caseBGreen]){
                        CurrentCase = EnumCase.caseBYellow;
                        tempCaseDuration = 0;
                    }
                    break;
                case EnumCase.caseBYellow:
                    if(tempCaseDuration == CaseDurations[(int)EnumCase.caseBYellow]){
                        CurrentCase = EnumCase.caseCGreen;
                        tempCaseDuration = 0;
                    }
                    break;
                case EnumCase.caseCGreen:
                    if(tempCaseDuration == CaseDurations[(int)EnumCase.caseCGreen]){
                        CurrentCase = EnumCase.caseCYellow;
                        tempCaseDuration = 0;
                    }
                    break;
                case EnumCase.caseCYellow:
                    if(tempCaseDuration == CaseDurations[(int)EnumCase.caseCYellow]){
                        if (this is WithPedestrian) CurrentCase = EnumCase.caseDGreen;
                        else CurrentCase = EnumCase.caseAGreen;
                        tempCaseDuration = 0;
                    }
                    break;
                case EnumCase.caseDGreen:
                    if(tempCaseDuration == CaseDurations[(int)EnumCase.caseDGreen]){
                        CurrentCase = EnumCase.caseDYellow;
                        tempCaseDuration = 0;
                    }
                    break;
                case EnumCase.caseDYellow:
                    if(tempCaseDuration == CaseDurations[(int)EnumCase.caseDYellow]){
                        CurrentCase = EnumCase.caseAGreen;
                        tempCaseDuration = 0;
                    }
                    break;
                default:
                    break;
            }
        
        }

        public List<Lane> GetLanes(EnumDirection dir)
        {
            int i = 0;
            List<Lane> temp = new List<Lane>();
            foreach (Lane l in CrossingLane)
            {
                if (l.Direction == dir)
                {
                    temp.Add(l);
                    i++;
                    if (i == 3) break;
                }
            }
            return temp;
        }
        
        /// <summary>
        /// Add pedestrian object to the Crossing
        /// </summary>
        /// <param name="p"></param>
        /// <param name="laneId"></param>
        public void AddPedestrianToLane(Pedestrian p, int laneId)
        {
            if (crossingType == EnumSelectedCrossing.withPedestrian)
            {
                ((WithPedestrian)this).CrossingLane[laneId].AddPedestrianToLane(p);
            }

        }


        public virtual TrafficLight[] GetState()
        {
            return null; 
        }
    }
}
