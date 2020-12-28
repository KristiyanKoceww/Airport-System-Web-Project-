namespace AirportSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using AirportSystem.Services.Data.Airport;
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AirportsController : AdminController
    {
        private readonly IAirportService airportService;
        private readonly ICityService cityService;

        public AirportsController(IAirportService airportService, ICityService cityService)
        {
            this.airportService = airportService;
            this.cityService = cityService;
        }

        public IActionResult Create()
        {
            var viewModel = new AirportInputModel();
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(AirportInputModel input)
        {
            var city = this.cityService.FindCityById(input.CityId);

            if (city == null)
            {
                return this.View("CityNotFound");
            }

            this.airportService.CreateAirport(input);
            return this.View();
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
