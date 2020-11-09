namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Services.Data.CitiesAndCountries;
    using Microsoft.AspNetCore.Mvc;

    public class CoutriesAndCitiesController : Controller
    {
        private readonly ICountryService countryService;

        public CoutriesAndCitiesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        public IActionResult All()
        {
            var viewModel = this.countryService.GetAll();
            return this.View(viewModel);
        }
    }
}
