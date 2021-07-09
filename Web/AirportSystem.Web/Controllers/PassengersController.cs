namespace AirportSystem.Web.Controllers
{
    using System.Security.Claims;
    using AirportSystem.Data;
    using AirportSystem.Data.Models;
    using AirportSystem.Services.Data;
    using AirportSystem.Services.Data.Luggages;
    using AirportSystem.Services.Data.Passengers;
    using AirportSystem.Web.ViewModels;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PassengersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPassengersService passengersService;
        private readonly IUserPassengersService userPassengersService;
        private readonly ILuggageService luggageService;


        public PassengersController(UserManager<ApplicationUser> userManager, IPassengersService passengersService, IUserPassengersService userPassengersService, ILuggageService luggageService)
        {
            this.userManager = userManager;
            this.passengersService = passengersService;
            this.userPassengersService = userPassengersService;
            this.luggageService = luggageService;

        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(Services.Data.InputModels.PassengerInputModel passengerInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(passengerInputModel);
            }

            this.passengersService.Create(passengerInputModel);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var passengerId = this.passengersService.GetPassengerId(passengerInputModel.FirstName, passengerInputModel.MiddleName, passengerInputModel.LastName);

            this.userPassengersService.Create(userId, passengerId);
            return this.Redirect("/Passports/edit");
        }

        public IActionResult GetAllPassengers()
        {
            var passegers = this.passengersService.GetAll();

            return this.View(passegers);
        }

        public IActionResult PassengerInfo()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.passengersService.GetPassengerByUserId(userId);
            if (user == null)
            {
                return this.Redirect("/Passengers/Add");
            }

            var viewModel = this.passengersService.GetOnePassenger<PassengerInfoViewModel>(user.PassengerId);
            var luggages = this.luggageService.GetLuggagesPassengerByPassId(user.PassengerId);
            viewModel.PassengerId = user.PassengerId;
            viewModel.Luggages = luggages;
            return this.View(viewModel);
        }
    }
}
