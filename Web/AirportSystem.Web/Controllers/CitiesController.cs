namespace AirportSystem.Web.Controllers
{
    using System;
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

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

            try
            {
                this.cityService.Create(citiesInputModel, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {

                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
