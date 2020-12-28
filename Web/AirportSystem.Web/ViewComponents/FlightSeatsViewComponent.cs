namespace AirportSystem.Web.ViewComponents
{
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data.Models.Planes;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.Seats;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class FlightSeatsViewComponent : ViewComponent
    {
        private readonly IFlightService flightService;
        private readonly ISeatsService seatsService;

        public FlightSeatsViewComponent(IFlightService flightService, ISeatsService seatsService)
        {
            this.flightService = flightService;
            this.seatsService = seatsService;
        }

        public IViewComponentResult Invoke(int flightId, string title)
        {
            var flight = this.flightService.GetFlightById(flightId);

            var seats = this.seatsService.GetSeatsByPlaneId(flight.PlaneId);

            var areSeatsAvailable = new Dictionary<Seat, bool>();

            foreach (var seat in seats)
            {
                areSeatsAvailable.Add(seat, seat.IsAvailable);
            }

            var viewModel = new BookSeatsViewModel()
            {
                Seats = seats.Count(),
                IsSeatAvailable = areSeatsAvailable,
            };

            return this.View(viewModel);
        }
    }
}
