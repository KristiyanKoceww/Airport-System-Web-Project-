namespace AirportSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Passports;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PassportsController : Controller
    {
        private readonly IPassportService passportService;

        public PassportsController(IPassportService passportService)
        {
            this.passportService = passportService;
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(PassportInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var passport = this.passportService.FindPassportById(input.Id);

            if (passport == null)
            {
                return this.View("PassportNotFound");
            }

            this.passportService.Edit(input);

            return this.Redirect("/Luggages/Create");
        }
    }
}
