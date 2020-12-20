namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Common;
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Services.Data.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CitiesController : Controller
    {
        private readonly ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        public async Task<IActionResult> Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CitiesInputModel citiesInputModel)
        {
            this.cityService.Create(citiesInputModel);
            return this.View();
        }

        public async Task<IActionResult> All()
        {
            return this.View();
        }
    }
}
