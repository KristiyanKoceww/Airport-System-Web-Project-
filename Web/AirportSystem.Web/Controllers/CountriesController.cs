namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Common;
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Services.Data.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CountriesController : Controller
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        public async Task<IActionResult> Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CountryInputModel countryInputModel)
        {
            this.countryService.Create(countryInputModel);
            return this.View();
        }

        public async Task<IActionResult> All()
        {
            return this.View();
        }
    }
}
