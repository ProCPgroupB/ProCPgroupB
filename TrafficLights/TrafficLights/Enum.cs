using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights
{
    /// <summary>
    /// Trafic colors
    /// Red, Yellow, Green
    /// </summary>
    enum EnumLights
    {
        red, yellow, green
    }
    /// <summary>
    /// Direction
    /// </summary>
    enum EnumDirection
    {
        North, East, South, West
    }
    /// <summary>
    /// Different cases according to the 
    /// </summary>
    enum EnumCase
    {
        case1,
        case2,
        case3,
        case4,
        case5
    }

    /// <summary>
    /// Directions of lane 
    /// </summary>
    enum EnumLaneDirection
    {
        North2East,
        North2South,
        North2West,
        East2North,
        East2West,
        East2South,
        South2East,
        South2West,
        South2North,
        West2North,
        West2South,
        West2East

    }
}
