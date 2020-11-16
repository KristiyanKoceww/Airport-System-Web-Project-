namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Services.Data.Airport;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class AirportsController : Controller
    {
        private readonly IAirportService airportService;

        public AirportsController(IAirportService airportService)
        {
            this.airportService = airportService;
        }

        public IActionResult Create()
        {
            var viewModel = new AirportInputModel();
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(AirportInputModel input)
        {
            this.airportService.CreateAirport(input);
            return this.View();
        }
    }
}
