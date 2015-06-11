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
    class WithoutPedestrian : Crossing
    {

        Point[][] LaneCollections = new Point[12][];

        // ------------------------- Constructor -------------------------
        /// <summary>
        /// Constructor of WithoutPedestrian
        /// </summary>
        /// <param name="type">type of the crossing</param>
        /// <param name="row">row location on the grid</param>
        /// <param name="col">col location on the grid</param>
        public WithoutPedestrian(EnumSelectedCrossing type, int row, int col)
            : base(type, row, col)
        {

            #region LaneCollections
            //LaneCollections[0] = new Point[]{
            //    new Point(260, 0),
            //    new Point(260, 200),
            //    new Point(240, 230),
            //    new Point(203, 230),
            //    new Point(200, 240),
            //    new Point(20, 240),
            //    new Point(0, 260)
            //};
            //LaneCollections[1] = new Point[]{
            //    new Point(260,0),
            //    new Point(300,60),
            //    new Point(300,200),
            //    new Point(240,400),
            //    new Point(240,580),
            //    new Point(260,600)
            //};
            //LaneCollections[2] = new Point[]{
            //    new Point(260,0),
            //        new Point(300,60),
            //        new Point(300,200),
            //        new Point(340,320),
            //        new Point(400,360),
            //        new Point(580,360),
            //        new Point(600,340)
            //};
            //LaneCollections[3] = new Point[]{
            //    new Point(600,260),
            //        new Point(540,240),
            //        new Point(400,240),
            //        new Point(370,230),
            //        new Point(360,200),
            //        new Point(360,20),
            //        new Point(340,0)
            //};
            //LaneCollections[4] = new Point[]{
            //    new Point(600,260),
            //        new Point(540,300),
            //        new Point(400,300),
            //        new Point(200,240),
            //        new Point(20,240),
            //        new Point(0,260)
            //};
            //LaneCollections[5] = new Point[]{
            //   new Point(600,260),
            //        new Point(540,300),
            //        new Point(400,300),
            //        new Point(280,340),
            //        new Point(240,400),
            //        new Point(240,580),
            //        new Point(260,600)
            //};
            //LaneCollections[6] = new Point[]{
            //    new Point(340,600),
            //        new Point(360,540),
            //        new Point(360,400),
            //        new Point(370,370),
            //        new Point(400,360),
            //        new Point(580,360),
            //        new Point(600,340)
            //};
            //LaneCollections[7] = new Point[]{
            //    new Point(340,600),
            //        new Point(300,540),
            //        new Point(300,400),
            //        new Point(360,200),
            //        new Point(360,20),
            //        new Point(340,0)
            //};
            //LaneCollections[8] = new Point[]{
            //   new Point(340,600),
            //        new Point(300,540),
            //        new Point(300,400),
            //        new Point(260,280),
            //        new Point(200,240),
            //        new Point(20,240),
            //        new Point(0,260)
            //};
            //LaneCollections[9] = new Point[]{
            //     new Point(0,340),
            //        new Point(60,360),
            //        new Point(200,360),
            //        new Point(230,370),
            //        new Point(240,400),
            //        new Point(240,580),
            //        new Point(260,600)
            //};
            //LaneCollections[10] = new Point[]{
            //    new Point(0,340),
            //        new Point(60,300),
            //        new Point(200,300),
            //        new Point(400,360),
            //        new Point(580,360),
            //        new Point(600,340)
            //};
            //LaneCollections[11] = new Point[]{
            //     new Point(0,340),
            //        new Point(60,300),
            //        new Point(200,300),
            //        new Point(320,260),
            //        new Point(360,200),
            //        new Point(360,20),
            //        new Point(340,0)
            //};
            

            //Lanes.Add(new Lane(EnumDirection.North, 5, col, row, LaneCollections[0], 0));
            //Lanes.Add(new Lane(EnumDirection.North, 5, col, row, LaneCollections[1],1));
            //Lanes.Add(new Lane(EnumDirection.North, 5, col, row, LaneCollections[2], 1));
            //Lanes.Add(new Lane(EnumDirection.East, 5, col, row, LaneCollections[3], 2));
            //Lanes.Add(new Lane(EnumDirection.East, 5, col, row, LaneCollections[4], 3));
            //Lanes.Add(new Lane(EnumDirection.East, 5, col, row, LaneCollections[5], 3));
            //Lanes.Add(new Lane(EnumDirection.South, 5, col, row, LaneCollections[6], 4));
            //Lanes.Add(new Lane(EnumDirection.South, 5, col, row, LaneCollections[7], 5));
            //Lanes.Add(new Lane(EnumDirection.South, 5, col, row, LaneCollections[8], 5));
            //Lanes.Add(new Lane(EnumDirection.West, 5, col, row, LaneCollections[9], 6));
            //Lanes.Add(new Lane(EnumDirection.West, 5, col, row, LaneCollections[10], 7));
            //Lanes.Add(new Lane(EnumDirection.West, 5, col, row, LaneCollections[11], 7));
            #endregion

            this.GenerateCases();
            this.GenerateTrafficLight();

        }

        // --------------------------- Methods ---------------------------

        public void GenerateCases()
        {
            CaseDurations[(int)EnumCase.caseAGreen] = 5;
            CaseDurations[(int)EnumCase.caseAYellow] = 2;
            CaseDurations[(int)EnumCase.caseBGreen] = 5;
            CaseDurations[(int)EnumCase.caseBYellow] = 2;
            CaseDurations[(int)EnumCase.caseCGreen] = 5;
            CaseDurations[(int)EnumCase.caseCYellow] = 2;
            CaseDurations[(int)EnumCase.caseDGreen] = 5;
            CaseDurations[(int)EnumCase.caseDYellow] = 2;
        }

        /// <summary>
        /// Generate TrafficLight
        /// </summary>
        public void GenerateTrafficLight()
        {
            TrafficLightsList = new TrafficLight[8];

            // trafficLightCollections
            for (int i = 0; i < TrafficLightsList.Count(); i++)
            {
                TrafficLightsList[i] = new TrafficLight();
            }

            #region generate TrafficLights
            
            // North1
            TrafficLightsList[0].GreenPos = new Point(70, 64);
            TrafficLightsList[0].YellowPos = new Point(75, 64);
            TrafficLightsList[0].RedPos = new Point(81, 64);
            TrafficLightsList[0].ShowTrafficLight = new Rectangle(new Point(222, 181), new Size(15, 3));

            // North2
            TrafficLightsList[1].GreenPos = new Point(92, 64);
            TrafficLightsList[1].YellowPos = new Point(97, 64);
            TrafficLightsList[1].RedPos = new Point(103, 64);
            TrafficLightsList[1].ShowTrafficLight = new Rectangle(new Point(281, 181), new Size(15, 3));

            // East1
            TrafficLightsList[2].GreenPos = new Point(131, 70);
            TrafficLightsList[2].YellowPos = new Point(131, 75);
            TrafficLightsList[2].RedPos = new Point(131, 81);
            TrafficLightsList[2].ShowTrafficLight = new Rectangle(new Point(415, 219), new Size(15, 3));

            // East2
            TrafficLightsList[3].GreenPos = new Point(131, 92);
            TrafficLightsList[3].YellowPos = new Point(131, 97);
            TrafficLightsList[3].RedPos = new Point(131, 103);
            TrafficLightsList[3].ShowTrafficLight = new Rectangle(new Point(415, 282), new Size(15, 3));

            // South1
            TrafficLightsList[4].GreenPos = new Point(125, 131);
            TrafficLightsList[4].YellowPos = new Point(120, 131);
            TrafficLightsList[4].RedPos = new Point(114, 131);
            TrafficLightsList[4].ShowTrafficLight = new Rectangle(new Point(348, 415), new Size(15, 3));

            // South2
            TrafficLightsList[5].GreenPos = new Point(103, 131);
            TrafficLightsList[5].YellowPos = new Point(98, 131);
            TrafficLightsList[5].RedPos = new Point(93, 131);
            TrafficLightsList[5].ShowTrafficLight = new Rectangle(new Point(283, 415), new Size(15, 3));

            // West1
            TrafficLightsList[6].GreenPos = new Point(65, 125);
            TrafficLightsList[6].YellowPos = new Point(65, 120);
            TrafficLightsList[6].RedPos = new Point(65, 114);
            TrafficLightsList[6].ShowTrafficLight = new Rectangle(new Point(176, 348), new Size(15, 3));

            // West2
            TrafficLightsList[7].GreenPos = new Point(65, 103);
            TrafficLightsList[7].YellowPos = new Point(65, 98);
            TrafficLightsList[7].RedPos = new Point(65, 92);
            TrafficLightsList[7].ShowTrafficLight = new Rectangle(new Point(176, 286), new Size(15, 3));
            #endregion
        }

        public override TrafficLight[] GetState()
        {
            for (int i = 0; i < TrafficLightsList.Count(); i++)
            {
                TrafficLightsList[i].LightState = EnumLights.red;
            }

            #region Control Other Lights
            switch (CurrentCase)
            {
                case EnumCase.caseAGreen:
                    TrafficLightsList[0].LightState = EnumLights.green;
                    TrafficLightsList[1].LightState = EnumLights.green;
                    TrafficLightsList[2].LightState = EnumLights.green;
                    break;
                case EnumCase.caseAYellow:
                    TrafficLightsList[0].LightState = EnumLights.yellow;
                    TrafficLightsList[1].LightState = EnumLights.yellow;
                    TrafficLightsList[2].LightState = EnumLights.yellow;
                    break;
                case EnumCase.caseBGreen:
                    TrafficLightsList[2].LightState = EnumLights.green;
                    TrafficLightsList[3].LightState = EnumLights.green;
                    TrafficLightsList[4].LightState = EnumLights.green;
                    break;
                case EnumCase.caseBYellow:
                    TrafficLightsList[2].LightState = EnumLights.yellow;
                    TrafficLightsList[3].LightState = EnumLights.yellow;
                    TrafficLightsList[4].LightState = EnumLights.yellow;
                    break;
                case EnumCase.caseCGreen:
                    TrafficLightsList[4].LightState = EnumLights.green;
                    TrafficLightsList[5].LightState = EnumLights.green;
                    TrafficLightsList[6].LightState = EnumLights.green;
                    break;
                case EnumCase.caseCYellow:
                    TrafficLightsList[4].LightState = EnumLights.yellow;
                    TrafficLightsList[5].LightState = EnumLights.yellow;
                    TrafficLightsList[6].LightState = EnumLights.yellow;
                    break;
                case EnumCase.caseDGreen:
                    TrafficLightsList[6].LightState = EnumLights.green;
                    TrafficLightsList[7].LightState = EnumLights.green;
                    TrafficLightsList[0].LightState = EnumLights.green;
                    break;
                case EnumCase.caseDYellow:
                    TrafficLightsList[6].LightState = EnumLights.yellow;
                    TrafficLightsList[7].LightState = EnumLights.yellow;
                    TrafficLightsList[0].LightState = EnumLights.yellow;
                    break;
                default:
                    break;
            }
            #endregion

            return TrafficLightsList;

        }



      
    }
}
