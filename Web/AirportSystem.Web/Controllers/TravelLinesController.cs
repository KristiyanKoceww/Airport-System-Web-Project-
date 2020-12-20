namespace AirportSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.TravelLines;
    using AirportSystem.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class TravelLinesController : AdminController
    {
        private readonly ITravelLinesService travelLinesService;

        public TravelLinesController(ITravelLinesService travelLinesService)
        {
            this.travelLinesService = travelLinesService;
        }

        public async Task<IActionResult> Create()
        {
           return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TravelLineInputModel travelLineInputModel)
        {
            this.travelLinesService.CreateTravelLine(travelLineInputModel);

            return this.View();
        }

        public async Task<IActionResult> All()
        {
            return this.View();
        }
    }
}
