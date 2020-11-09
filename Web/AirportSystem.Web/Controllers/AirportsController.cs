namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Services.Data.Airport;
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
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateAirportViewModel createAirportViewModel)
        {
           // this.airportService.CreateAirport(createAirportViewModel);
            return this.View();
        }
    }
}
