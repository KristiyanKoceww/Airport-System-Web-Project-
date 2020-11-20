namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Common;
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Services.Data.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CitiesController : Controller
    {
        private readonly ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(CitiesInputModel citiesInputModel)
        {
            this.cityService.Create(citiesInputModel);
            return this.View();
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
