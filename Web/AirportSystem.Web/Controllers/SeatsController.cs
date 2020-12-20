namespace AirportSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using AirportSystem.Services.Data.Seats;
    using AirportSystem.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class SeatsController : AdminController
    {
        private readonly ISeatsService seatsService;

        public SeatsController(ISeatsService seatsService)
        {
            this.seatsService = seatsService;
        }

        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(bool isAvailable, int seatsCount, int planeId)
        {
            this.seatsService.Create(isAvailable, seatsCount, planeId);

            return this.View();
        }
    }
}
