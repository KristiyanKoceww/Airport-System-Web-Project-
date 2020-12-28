namespace AirportSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AirportSystem.Data.Models;
    using AirportSystem.Data.Models.Passengers;
    using AirportSystem.Services.Data;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Passengers;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PassengersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPassengersService passengersService;
        private readonly IUserPassengersService userPassengersService;

        public PassengersController(UserManager<ApplicationUser> userManager, IPassengersService passengersService, IUserPassengersService userPassengersService)
        {
            this.userManager = userManager;
            this.passengersService = passengersService;
            this.userPassengersService = userPassengersService;
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

        public IActionResult PassengerInfo()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.passengersService.GetPassengerByUserId(userId);
            if (user == null)
            {
                return this.Redirect("/Passengers/Add");
            }

            var passenger = this.passengersService.GetPassengerById(user.PassengerId);

            var viewModel = new PassengerInfoViewModel
            {
                FirstName = passenger.FirstName,
                MiddleName = passenger.MiddleName,
                LastName = passenger.LastName,
                Address = passenger.Address,
                Age = passenger.Age,
                Phone = passenger.Phone,
                PassportId = passenger.PassportId,
            };
            viewModel.Phone = passenger.Phone;
            viewModel.PassengerId = user.PassengerId;

            return this.View("PassengerInfo", viewModel);
        }
    }
}
