using System;
using System.Collections.Generic;
using System.Text;

namespace LinqInManhattan.JsonClasses
{
    /// <summary>
    /// Class representing the JSON Geometry object in C#
    /// </summary>
    class Geometry
    {
        public string Type { get; set; }
        public double[] Coordinates { get; set; }
    }
}
