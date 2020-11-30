namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Common;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.TravelLines;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create(FlightInputModel flightInputModel)
        {
            this.flightService.Create(flightInputModel);
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult All2()
        {
            return this.View();
        }

        public IActionResult GetFlightById()
        {
            // var viewModel = new GetFlightByIdViewModel();
            return this.View();
        }

        [HttpPost]
        public IActionResult GetFlightById(int flightId)
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

        public IActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Search(SearchForFlightViewModel flight)
        {
            var flights = this.flightService.SearchForFlight(flight.Origin, flight.Destination);

            if (flights == null)
            {
                return this.NotFound();
            }

            return this.View("SearchResults", flights);
        }
    }
}
