namespace AirportSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using AirportSystem.Common;
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;

    [Authorize]
    public class CitiesController : AdminController
    {
        private readonly ICityService cityService;
        private readonly ICountryService countryService;
        private readonly IWebHostEnvironment environment;

        public CitiesController(ICityService cityService, ICountryService countryService, IWebHostEnvironment environment)
        {
            this.cityService = cityService;
            this.countryService = countryService;
            this.environment = environment;
        }

        public IActionResult ExtendCity()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult ExtendCity(ExtendCityInputModel input)
        {
            this.cityService.AddImageAndDescriptionToCity(input, $"{this.environment.WebRootPath}/images");
            this.TempData["Message"] = "Extend city was successfully.";
            return this.View("succsessfuly");
        }


        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(CitiesInputModel citiesInputModel)
        {
            var country = this.countryService.FindCountryById(citiesInputModel.CountryId);

            if (country == null)
            {
                return this.View("CountryNotFound");
            }

            this.cityService.Create(citiesInputModel);
            return this.View();
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
