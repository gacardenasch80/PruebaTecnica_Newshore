using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_Newshore.Data.Model
{
    public class Journey
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public List<Flight> Flights { get; set; }
    }

    public class FlightRouteResult
    {
        public Journey Journey { get; set; }
    }
}
