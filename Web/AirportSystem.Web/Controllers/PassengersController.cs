﻿namespace AirportSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Security.Claims;

    using AirportSystem.Data.Models;
    using AirportSystem.Data.Models.Passengers;
    using AirportSystem.Services.Data;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Passengers;
    using AirportSystem.Web.Controllers;
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
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(PassengerInputModel passengerInputModel)
        {
            this.passengersService.Create(passengerInputModel);

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var passengerId = this.passengersService.GetPassengerId(passengerInputModel.FirstName, passengerInputModel.MiddleName, passengerInputModel.LastName);

            this.userPassengersService.Create(userId, passengerId);
            return this.View();
        }
    }
}
