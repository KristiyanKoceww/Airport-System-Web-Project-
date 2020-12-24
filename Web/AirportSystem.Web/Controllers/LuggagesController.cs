namespace AirportSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Luggages;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class LuggagesController : Controller
    {
        private readonly ILuggageService luggageService;

        public LuggagesController(ILuggageService luggageService)
        {
            this.luggageService = luggageService;
        }

        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LuggageInputModel luggageInputModel)
        {
            this.luggageService.Create(luggageInputModel);
            return this.View();
        }

        public async Task<IActionResult> Search()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(int Id)
        {
            var luggage = this.luggageService.GetLuggageById(Id);

            var viewModel = new SearchLuggageViewModel()
            {
                Id = luggage.Id,
                PassengerId = luggage.PassengerId,
                PassengerFirstName = luggage.PassengerFirstName,
                LuggageType = luggage.LuggageType,
                Weight = luggage.Weight,
            };

            return this.View("SearchResults", viewModel);
        }
    }
}
