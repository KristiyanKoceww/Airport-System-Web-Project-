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

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(LuggageInputModel luggageInputModel)
        {
            var passenger = this.passengersService.GetPassengerById(luggageInputModel.PassengerId);
            if (passenger == null)
            {
                return this.View();
            }

            this.luggageService.Create(luggageInputModel);
            return this.View();
        }

        public IActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Search(int id)
        {
            var luggage = this.luggageService.GetLuggageById(id);

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
