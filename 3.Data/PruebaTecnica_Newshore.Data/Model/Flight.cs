using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_Newshore.Data.Model
{
    public class Flight
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public Transport Transport { get; set; }
    }
}
