namespace AirportSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using AirportSystem.Common;
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class CitiesController : AdminController
    {
        private readonly ICityService cityService;
        private readonly ICountryService countryService;

        public CitiesController(ICityService cityService, ICountryService countryService)
        {
            this.cityService = cityService;
            this.countryService = countryService;
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
