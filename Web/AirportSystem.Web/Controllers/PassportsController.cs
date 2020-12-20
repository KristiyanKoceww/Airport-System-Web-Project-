namespace AirportSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Passports;
    using Microsoft.AspNetCore.Mvc;

    public class PassportsController : Controller
    {
        private readonly IPassportService passportService;

        public PassportsController(IPassportService passportService)
        {
            this.passportService = passportService;
        }

        public async Task<IActionResult> Edit()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PassportInputModel input)
        {
            this.passportService.Edit(input);
            return this.View();
        }
    }
}
