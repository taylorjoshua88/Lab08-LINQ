﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinqInManhattan.JsonClasses
{
    /// <summary>
    /// Class representing the Properties JSON object in C#
    /// </summary>
    class Properties
    {
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Borough { get; set; }
        public string Neighborhood { get; set; }
        public string County { get; set; }
    }
}
