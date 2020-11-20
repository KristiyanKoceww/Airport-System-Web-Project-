namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Common;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class FlightsController : Controller
    {
        private readonly IFlightService flightService;

        public FlightsController(IFlightService flightService)
        {
            this.flightService = flightService;
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

        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult GetFlightById(int flightId)
        {
            this.flightService.GetFlightById(flightId);
            return this.View();
        }
    }
}
