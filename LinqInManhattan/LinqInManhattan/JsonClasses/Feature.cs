using System;
using System.Collections.Generic;
using System.Text;

namespace LinqInManhattan.JsonClasses
{
    /// <summary>
    /// Class representing the Feature JSON object in C#
    /// </summary>
    class Feature
    {
        public string Type { get; set; }
        public Geometry Geometry { get; set; }
        public Properties Properties { get; set; }
    }
}
