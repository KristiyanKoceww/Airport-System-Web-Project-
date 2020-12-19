namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Services.Data.Seats;
    using Microsoft.AspNetCore.Mvc;

    public class SeatsController : BaseController
    {
        private readonly ISeatsService seatsService;

        public SeatsController(ISeatsService seatsService)
        {
            this.seatsService = seatsService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(bool isAvailable, int seatsCount, int planeId)
        {
            this.seatsService.Create(isAvailable, seatsCount, planeId);

            return this.View();
        }
    }
}
