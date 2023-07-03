using System.Text.Json;
using PruebaTecnica_Newshore.Data.Model;
using PruebaTecnica_Newshore.Service.ExternService;
using PruebaTecnica_Newshore.Service.Server.Interface;
using PruebaTecnica_Newshore.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnica_Newshore.Service.ExternService.Model;

namespace PruebaTecnica_Newshore.Service.Server.Implementation
{
    public class JourneyService: IJourneyService
    {
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// Constructor de la clase AuthorService
        /// </summary>
        /// <param name="unitOfWork"></param>
        public JourneyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FlightRouteResult> JourneyGet(string origin, string destination, int? numeroMaxVuelos)
        {
            var flights = await NewshoreRestApi.GetFlights("2");

            FlightRouteResult result = new FlightRouteResult
            {
                Journey = new Journey
                {
                    Origin = origin,
                    Destination = destination,
                    Price = 0,
                    Flights = new List<Flight>()
                }
            };

            List<NewshoreFlights> remainingFlights = new List<NewshoreFlights>(flights);
            int count = 1;
            NewshoreFlights nextFlight = new NewshoreFlights();
            while (origin != destination)
            {
                nextFlight = remainingFlights.FirstOrDefault(f => f.DepartureStation == origin && f.ArrivalStation==destination);
                if (nextFlight == null)
                {
                    nextFlight = remainingFlights.FirstOrDefault(f => f.DepartureStation == origin);
                }

                if (nextFlight == null)
                {
                    result.Journey = null; // No se encontró una ruta válida
                    break;
                }
                if ((numeroMaxVuelos!=null) && (numeroMaxVuelos >= 0))
                {
                    if (count > numeroMaxVuelos) {
                        result.Journey = null; // El numero maximo de vuelos fue superado
                        break;
                    }
                }
                Flight flight = new Flight
                {
                    Origin = nextFlight.DepartureStation,
                    Destination = nextFlight.ArrivalStation,
                    Price = nextFlight.Price,
                    Transport = new Transport
                    {
                        FlightCarrier = nextFlight.FlightCarrier,
                        FlightNumber = nextFlight.FlightNumber
                    }
                };

                result.Journey.Flights.Add(flight);
                result.Journey.Price += flight.Price;

                origin = nextFlight.ArrivalStation;
                remainingFlights.Remove(nextFlight);
                count++;
            }


            return result;
        }
    }
}
