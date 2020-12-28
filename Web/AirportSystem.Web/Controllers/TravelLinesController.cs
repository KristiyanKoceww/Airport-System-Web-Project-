namespace AirportSystem.Web.Controllers
{
    using System.Threading.Tasks;
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.TravelLines;
    using AirportSystem.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class TravelLinesController : AdminController
    {
        private readonly ITravelLinesService travelLinesService;
        private readonly ICityService cityService;

        public TravelLinesController(ITravelLinesService travelLinesService,ICityService cityService)
        {
            this.travelLinesService = travelLinesService;
            this.cityService = cityService;
        }

        public IActionResult Create()
        {
           return this.View();
        }

        [HttpPost]
        public IActionResult Create(TravelLineInputModel travelLineInputModel)
        {
            var city = this.cityService.FindCityById(travelLineInputModel.CityId);
            var city2 = this.cityService.FindCityById(travelLineInputModel.City2Id);

            if (city == null || city2 == null)
            {
                return this.View("CityNotFound");
            }

            this.travelLinesService.CreateTravelLine(travelLineInputModel);

            return this.View();
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
