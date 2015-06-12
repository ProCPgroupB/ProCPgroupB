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
    /// 
    /// </summary>
    class WithPedestrian : Crossing
    {

        // -------------------------- Properties --------------------------
        
        Point[][] LaneCollections = new Point[16][];

        public int p1Capacity = 5;
        public int p2Capacity = 5;
        public int p3Capacity = 5;
        public int p4Capacity = 5;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of WithPedestrian
        /// </summary>
        /// <param name="type">type of the crossing</param>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        public WithPedestrian(EnumSelectedCrossing type, int row, int col)
            : base(type, row, col)
        {
            CrossingLane = new List<Lane>();
            
            this.GenereateLanes();
            this.GenerateCases();
            this.GenerateTrafficLight();

        }

        // --------------------------- Methods ---------------------------

        public void GenereateLanes()
        {
            #region North
            // N1 to W3
            LaneCollections[0] = new Point[]{
                new Point(80, 0),
                new Point(80, 66),
                new Point(75, 76),
                new Point(62, 76),
                new Point(14, 76),
                new Point(0, 76),
            };

            // N1 to S2
            LaneCollections[1] = new Point[]{
                new Point(80, 0),
                new Point(80, 200),
            };

            // N1 to E3 - 6 point
            LaneCollections[2] = new Point[]{
                new Point(80, 0),
                new Point(80, 66),
                new Point(110, 110),
                new Point(133, 119),
                new Point(178, 119),
                new Point(200, 76),
            };
            #endregion

            #region East
            // E1 to N2 - 6 point
            LaneCollections[3] = new Point[]{
                new Point(200, 76),
                new Point(133, 76),
                new Point(116, 75),
                new Point(112, 60),
                new Point(112, 16),
                new Point(112, 0),
            };

            // E2 to W3 - 4 point
            LaneCollections[4] = new Point[]{
                new Point(200, 76),
                new Point(133, 76),
                new Point(62, 76),
                new Point(0, 76),
            };
            // E2 to S2 - 6 point
            LaneCollections[5] = new Point[]{
                new Point(200, 76),
                new Point(178, 97),
                new Point(133, 97),
                new Point(93, 112),
                new Point(80, 133),
                new Point(80, 200),
            };
            #endregion

            #region South
            // S1 to E3 - 6 point
            LaneCollections[6] = new Point[]{
                new Point(113, 200),
                new Point(113, 133),
                new Point(120, 120),
                new Point(134, 120),
                new Point(200, 120),
            };
            // S1 to N2 - 2 point
            LaneCollections[7] = new Point[]{
                new Point(113, 200),
                new Point(113, 0),
            };
            // S1 to W3 - 6 point
            LaneCollections[8] = new Point[]{
                new Point(113, 200),
                new Point(113, 133),
                new Point(98, 98),
                new Point(83, 87),
                new Point(60, 76),
                new Point(0, 76),
            };
            #endregion

            #region West
            // W1 to S2 - 6 point
            LaneCollections[9] = new Point[]{
                new Point(0, 120),
                new Point(60, 120),
                new Point(75, 124),
                new Point(80, 138),
                new Point(80, 200),
            };
            // W1 to E3 - 4 point
            LaneCollections[10] = new Point[]{
                new Point(0, 120),
                new Point(200, 120),
            };
            // W2 to N2 - 6 point
            LaneCollections[11] = new Point[]{
                new Point(0, 120),
                new Point(20, 98),
                new Point(58, 98),
                new Point(98, 88),
                new Point(113, 62),
                new Point(113, 0),
            };
            #endregion

            #region Pedestrian

            // P1 to P2
            LaneCollections[12] = new Point[]{
                new Point(27, 30),
                new Point(57, 30),
                new Point(57, 50),
                new Point(139, 50),
                new Point(139, 0),
            };
            // P2 to P1
            LaneCollections[13] = new Point[]{
                new Point(139, 0),
                new Point(139, 55),
                new Point(57, 55),
                new Point(40, 57),
                new Point(0, 57),
            };
            // P3 to P4
            LaneCollections[14] = new Point[]{
                new Point(0, 138),
                new Point(40, 138),
                new Point(57, 142),
                new Point(138, 142),
                new Point(138, 200),
            };
            // P4 to P3
            LaneCollections[15] = new Point[]{
                new Point(175, 173),
                new Point(138, 173),
                new Point(138, 142),
                new Point(57, 142),
                new Point(40, 138),
                new Point(0, 138),
            };

            #endregion

            // Add to crossing lane

            // Car lanes
            CrossingLane.Add(new Lane(EnumDirection.North, LaneCollections[0], 0));
            CrossingLane.Add(new Lane(EnumDirection.North, LaneCollections[1], 0));
            CrossingLane.Add(new Lane(EnumDirection.North, LaneCollections[2], 0));

            CrossingLane.Add(new Lane(EnumDirection.East, LaneCollections[3], 1));
            CrossingLane.Add(new Lane(EnumDirection.East, LaneCollections[4], 1));
            CrossingLane.Add(new Lane(EnumDirection.East, LaneCollections[5], 2));

            CrossingLane.Add(new Lane(EnumDirection.South, LaneCollections[6], 3));
            CrossingLane.Add(new Lane(EnumDirection.South, LaneCollections[7], 3));
            CrossingLane.Add(new Lane(EnumDirection.South, LaneCollections[8], 3));

            CrossingLane.Add(new Lane(EnumDirection.West, LaneCollections[9], 4));
            CrossingLane.Add(new Lane(EnumDirection.West, LaneCollections[10], 5));
            CrossingLane.Add(new Lane(EnumDirection.West, LaneCollections[11], 6));

            // Pedestrian Lanes
            CrossingLane.Add(new Lane(EnumDirection.North, LaneCollections[12], 6));
            CrossingLane.Add(new Lane(EnumDirection.North, LaneCollections[13], 7));
            CrossingLane.Add(new Lane(EnumDirection.South, LaneCollections[14], 8));
            CrossingLane.Add(new Lane(EnumDirection.South, LaneCollections[15], 9));
        
        }

        public void GenerateCases()
        {
            CaseDurations[(int)EnumCase.caseAGreen] = 4;
            CaseDurations[(int)EnumCase.caseAYellow] = 2;
            CaseDurations[(int)EnumCase.caseBGreen] = 4;
            CaseDurations[(int)EnumCase.caseBYellow] = 2;
            CaseDurations[(int)EnumCase.caseCGreen] = 4;
            CaseDurations[(int)EnumCase.caseCYellow] = 2;
            CaseDurations[(int)EnumCase.caseDGreen] = 4;
            CaseDurations[(int)EnumCase.caseDYellow] = 5;
        }

        /// <summary>
        /// Generate TrafficLight
        /// </summary>
        public void GenerateTrafficLight()
        {
            TrafficLightsList = new TrafficLight[10];

            // trafficLightCollections
            for (int i = 0; i < TrafficLightsList.Count(); i++)
            {
                TrafficLightsList[i] = new TrafficLight();
            }

            #region generate TrafficLights

            // North1
            TrafficLightsList[0].GreenPos = new Point(76, 64);
            TrafficLightsList[0].YellowPos = new Point(81, 64);
            TrafficLightsList[0].RedPos = new Point(87, 64);
            TrafficLightsList[0].ShowTrafficLight = new Rectangle(new Point(73, 56), new Size(20, 5));

            // East1
            TrafficLightsList[1].GreenPos = new Point(131, 70);
            TrafficLightsList[1].YellowPos = new Point(131, 75);
            TrafficLightsList[1].RedPos = new Point(131, 81);
            TrafficLightsList[1].ShowTrafficLight = new Rectangle(new Point(139, 68), new Size(5, 20));

            // East2
            TrafficLightsList[2].GreenPos = new Point(131, 92);
            TrafficLightsList[2].YellowPos = new Point(131, 97);
            TrafficLightsList[2].RedPos = new Point(131, 103);
            TrafficLightsList[2].ShowTrafficLight = new Rectangle(new Point(139, 90), new Size(5, 20));

            // South1
            TrafficLightsList[3].GreenPos = new Point(120, 131);
            TrafficLightsList[3].YellowPos = new Point(114, 131);
            TrafficLightsList[3].RedPos = new Point(109, 131);
            TrafficLightsList[3].ShowTrafficLight = new Rectangle(new Point(106, 139), new Size(20, 5));

            // West1
            TrafficLightsList[4].GreenPos = new Point(65, 125);
            TrafficLightsList[4].YellowPos = new Point(65, 120);
            TrafficLightsList[4].RedPos = new Point(65, 114);
            TrafficLightsList[4].ShowTrafficLight = new Rectangle(new Point(56, 113), new Size(5, 20));

            // West2
            TrafficLightsList[5].GreenPos = new Point(65, 103);
            TrafficLightsList[5].YellowPos = new Point(65, 98);
            TrafficLightsList[5].RedPos = new Point(65, 92);
            TrafficLightsList[5].ShowTrafficLight = new Rectangle(new Point(56, 89), new Size(5, 20));

            // P1
            TrafficLightsList[6].GreenPos = new Point(59, 64);
            TrafficLightsList[6].YellowPos = new Point(59, 64);
            TrafficLightsList[6].RedPos = new Point(53, 64);
            TrafficLightsList[6].ShowTrafficLight = new Rectangle(new Point(63, 42), new Size(5, 20));

            // P2
            TrafficLightsList[7].GreenPos = new Point(137, 39);
            TrafficLightsList[7].YellowPos = new Point(137, 39);
            TrafficLightsList[7].RedPos = new Point(131, 39);
            TrafficLightsList[7].ShowTrafficLight = new Rectangle(new Point(136, 45), new Size(5, 15));

            // P3
            TrafficLightsList[8].GreenPos = new Point(143, 131);
            TrafficLightsList[8].YellowPos = new Point(143, 131);
            TrafficLightsList[8].RedPos = new Point(137, 131);
            TrafficLightsList[8].ShowTrafficLight = new Rectangle(new Point(60, 136), new Size(5, 20));

            // P4
            TrafficLightsList[9].GreenPos = new Point(59, 155);
            TrafficLightsList[9].YellowPos = new Point(59, 155);
            TrafficLightsList[9].RedPos = new Point(64, 155);
            TrafficLightsList[9].ShowTrafficLight = new Rectangle(new Point(136, 136), new Size(5, 20));
            #endregion
        }
       
        /// <summary>
        /// get traffic light states in the crossing
        /// </summary>
        /// <returns>array of traffic light states</returns>
        public override TrafficLight[] GetState() {
            for (int i = 0; i < TrafficLightsList.Count(); i++)
            {
                TrafficLightsList[i].LightState = EnumLights.red;
            }

            #region Control Other Lights
            switch (CurrentCase)
            {
                case EnumCase.caseAGreen:
                    TrafficLightsList[0].LightState = EnumLights.green;
                    TrafficLightsList[3].LightState = EnumLights.green;
                    break;
                case EnumCase.caseAYellow:
                    TrafficLightsList[0].LightState = EnumLights.yellow;
                    TrafficLightsList[3].LightState = EnumLights.yellow;
                    break;
                case EnumCase.caseBGreen:
                    TrafficLightsList[1].LightState = EnumLights.green;
                    TrafficLightsList[4].LightState = EnumLights.green;
                    break;
                case EnumCase.caseBYellow:
                    TrafficLightsList[1].LightState = EnumLights.yellow;
                    TrafficLightsList[4].LightState = EnumLights.yellow;
                    break;
                case EnumCase.caseCGreen:
                    TrafficLightsList[2].LightState = EnumLights.green;
                    TrafficLightsList[5].LightState = EnumLights.green;
                    break;
                case EnumCase.caseCYellow:
                    TrafficLightsList[2].LightState = EnumLights.yellow;
                    TrafficLightsList[5].LightState = EnumLights.yellow;
                    break;
                case EnumCase.caseDGreen:
                    TrafficLightsList[6].LightState = EnumLights.green;
                    TrafficLightsList[7].LightState = EnumLights.green;
                    TrafficLightsList[8].LightState = EnumLights.green;
                    TrafficLightsList[9].LightState = EnumLights.green;
                    break;
                case EnumCase.caseDYellow:
                    break;
                default:
                    break;
            }
            #endregion

            return TrafficLightsList;
        }

       
    }
}
