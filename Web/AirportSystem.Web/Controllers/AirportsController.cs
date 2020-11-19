namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Common;
    using AirportSystem.Services.Data.Airport;
    using AirportSystem.Services.Data.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
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

        public IActionResult All()
        {
            return this.View();
        }
    }
}
