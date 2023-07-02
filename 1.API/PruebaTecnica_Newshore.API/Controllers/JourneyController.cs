using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_Newshore.Data.Model;
using PruebaTecnica_Newshore.Service.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_Newshore.API.Controllers
{
    /// <summary>
    /// Controlador AuthorsController
    /// </summary>
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("[controller]")]
    public class JourneyController : Controller
    {
        private readonly IJourneyService _service;
        public JourneyController(IJourneyService service)
        {
            _service = service;
        }

        /// <summary>
        /// Function to get a Journey
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns>Expense type list</returns>
        /// <response code="200">Returns the get item</response>
        /// <response code="400">Model is not valid</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FlightRouteResult>> JourneyGet(string origin, string destination, int? numeroMaxVuelos)
        {
            var response = await _service.JourneyGet(origin, destination, numeroMaxVuelos);
            return Ok(response);
        }
    }
}
