using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights
{
    class StatisticCollector:TrafficControl
    {

        /********************************Fields***********************/

        




       /*******************************************Constructor**********************/
        /// <summary>
        /// Will have all the information of the Trafficontrol class
        /// </summary>
        public StatisticCollector() 
            :base()
        {

        }


        /*****************************************Methods*********************************/

        /// <summary>
        /// It will calculate the average of the car in the simulation
        /// </summary>
        /// <returns></returns>
        public double CarAverageOfCar()
        {
            return -1;
        }



        /// <summary>
        /// It will calculate the average of the Pedestrian in the simulation
        /// </summary>
        /// <returns></returns>
        public double PedestrianAverageOfCar()
        {
            return -1;
        }


        public void DrawTheStatistic() { }


    }
}
