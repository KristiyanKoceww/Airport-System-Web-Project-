namespace AirportSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using AirportSystem.Services.Data.Airport;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AirportsController : AdminController
    {
        private readonly IAirportService airportService;

        public AirportsController(IAirportService airportService)
        {
            this.airportService = airportService;
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new AirportInputModel();
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AirportInputModel input)
        {
            this.airportService.CreateAirport(input);
            return this.View();
        }

        public async Task<IActionResult> All()
        {
            return this.View();
        }
    }
}
