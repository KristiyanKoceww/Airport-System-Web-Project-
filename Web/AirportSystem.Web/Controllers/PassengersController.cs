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
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PassengersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPassengersService passengersService;
        private readonly IUserPassengersService userPassengersService;

        public PassengersController(UserManager<ApplicationUser> userManager, IPassengersService passengersService, IUserPassengersService userPassengersService )
        {
            this._userManager = userManager;
            this.passengersService = passengersService;
            this.userPassengersService = userPassengersService;
        }

        public IActionResult Add()
        {
            var viewModel = new PassengerInputModel();
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(PassengerInputModel passengerInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(passengerInputModel);
            }

            this.passengersService.Create(passengerInputModel);

           // var userId2 = await this._userManager.GetUserId(this.User);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var passengerId = this.passengersService.GetPassengerId(passengerInputModel.FirstName, passengerInputModel.MiddleName, passengerInputModel.LastName);

            this.userPassengersService.Create(userId, passengerId);
            return this.Redirect("/Passports/edit");
        }
    }
}
