using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights
{
    [Serializable]
    /// <summary>
    /// Trafic colors
    /// Red, Yellow, Green
    /// </summary>
    public enum EnumLights
    {
        red, yellow, green
    }
    /// <summary>
    /// Direction
    /// </summary>
    public enum EnumDirection
    {
        North, East, South, West
    }
    /// <summary>
    /// Different cases according to the 
    /// </summary>
    public enum EnumCase
    {
        caseAGreen,
        caseAYellow,
        caseBGreen,
        caseBYellow,
        caseCGreen,
        caseCYellow,
        caseDGreen,
        caseDYellow,
    }

    /// <summary>
    /// Directions of lane 
    /// </summary>
    public enum EnumPathDirection
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

    public enum EnumSelectedCrossing
    {
        withPedestrian,
        withoutPedestrian
    }
}
