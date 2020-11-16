namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.InputModels;
    using Microsoft.AspNetCore.Mvc;

    public class FlightsController : Controller
    {
        private readonly IFlightService flightService;

        public FlightsController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(FlightInputModel flightInputModel)
        {
            this.flightService.Create(flightInputModel);
            return this.View();
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
