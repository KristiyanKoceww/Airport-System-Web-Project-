namespace AirportSystem.Web.Controllers
{

    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Common;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.TravelLines;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class FlightsController : Controller
    {
        private readonly IFlightService flightService;
        private readonly ITravelLinesService travelLinesService;

        public FlightsController(IFlightService flightService, ITravelLinesService travelLinesService)
        {
            this.flightService = flightService;
            this.travelLinesService = travelLinesService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(FlightInputModel flightInputModel)
        {
            this.flightService.Create(flightInputModel);
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> All()
        {
            return this.View();
        }

        public async Task<IActionResult> All2()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> GetFlightById()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> GetFlightById(int flightId)
        {
            var flight = this.flightService.GetFlightById(flightId);
            var viewModel = new GetFlightByIdViewModel
            {
                PlaneId = flight.PlaneId,
                FlightStatus = flight.FlightStatus,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                FlightDuration = flight.FlightDuration,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Search(string origin, string destinaton)
        {
            var query = this.HttpContext.Response;
            var query2 = this.HttpContext.Request;
            this.ViewBag.From = origin;
            this.ViewBag.To = destinaton;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchForFlightViewModel flight)
        {
            var flights = this.flightService.SearchForFlight(flight.Origin, flight.Destination);

            if (flights.Count() == 0)
            {
                return this.View("NotFound");
            }

            return this.View("SearchResults", flights);
        }
    }
}
