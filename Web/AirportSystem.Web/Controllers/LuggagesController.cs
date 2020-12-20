﻿namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Luggages;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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
        public async Task<IActionResult> Search(int luggageId)
        {
            var luggage = this.luggageService.GetLuggageById(luggageId);
            return this.View();
        }
    }
}
