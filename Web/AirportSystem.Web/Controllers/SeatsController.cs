namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Services.Data.Seats;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class SeatsController : BaseController
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
