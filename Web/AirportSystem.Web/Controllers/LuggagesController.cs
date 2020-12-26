namespace AirportSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Luggages;
    using AirportSystem.Services.Data.Passengers;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class LuggagesController : Controller
    {
        private readonly ILuggageService luggageService;
        private readonly IPassengersService passengersService;

        public LuggagesController(
            ILuggageService luggageService,
            IPassengersService passengersService)

        {
            this.luggageService = luggageService;
            this.passengersService = passengersService;
        }

        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LuggageInputModel luggageInputModel)
        {

            var passenger = this.passengersService.GetPassengerById(luggageInputModel.PassengerId);
            if (passenger == null)
            {
                return this.View();

            }

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

            if (luggage == null)
            {
                return this.View("LuggageNotFound");
            }

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
