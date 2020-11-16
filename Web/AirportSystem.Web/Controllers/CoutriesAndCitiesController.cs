namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Services.Data.InputModels;
    using Microsoft.AspNetCore.Mvc;

    public class CoutriesAndCitiesController : Controller
    {
        private readonly ICountryService countryService;
        private readonly ICityService cityService;

        public CoutriesAndCitiesController(ICountryService countryService, ICityService cityService)
        {
            this.countryService = countryService;
            this.cityService = cityService;
        }

        public IActionResult All()
        {
            var view = new CitiesInputModel();
            var viewModel = this.cityService.GetAll();
            
            return this.View(viewModel);
        }
    }
}
