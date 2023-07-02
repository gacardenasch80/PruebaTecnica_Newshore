using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_Newshore.Service.ExternService.Model
{
    public class NewshoreFlights
    {
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set; }
        public int Price { get; set; }
    }
}
