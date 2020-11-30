namespace AirportSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.TravelLines;
    using Microsoft.AspNetCore.Mvc;

    public class TravelLinesController : BaseController
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
