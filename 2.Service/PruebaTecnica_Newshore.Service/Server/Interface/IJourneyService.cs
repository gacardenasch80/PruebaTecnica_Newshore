using PruebaTecnica_Newshore.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_Newshore.Service.Server.Interface
{
    public interface IJourneyService
    {
        Task<FlightRouteResult> JourneyGet(string origin, string destination, int? numeroMaxVuelos);
    }
}
