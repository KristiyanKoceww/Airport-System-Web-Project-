namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Luggages;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class LuggagesController : Controller
    {
        private readonly ILuggageService luggageService;

        public LuggagesController(ILuggageService luggageService)
        {
            this.luggageService = luggageService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(LuggageInputModel luggageInputModel)
        {
            this.luggageService.Create(luggageInputModel);
            return this.View();
        }

        public IActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Search(int luggageId)
        {
            var luggage = this.luggageService.GetLuggageById(luggageId);
            return this.View();
        }
    }
}
