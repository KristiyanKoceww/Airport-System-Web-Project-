namespace AirportSystem.Web.ViewComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AirportSystem.Data.Models.Planes;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.Planes;
    using AirportSystem.Services.Data.Seats;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class FlightSeatsViewComponent : ViewComponent
    {
        private readonly IFlightService flightService;
        private readonly ISeatsService seatsService;
        private readonly IPlaneService planeService;

        public FlightSeatsViewComponent(IFlightService flightService, ISeatsService seatsService)
        {
            this.flightService = flightService;
            this.seatsService = seatsService;
        }

        public IViewComponentResult Invoke(int flightId, string title)
        {
            var flight = this.flightService.GetFlightById(flightId);
            var seats = this.seatsService.GetSeatsByPlaneId(flight.PlaneId);

            var AreSeatsAvailable = new Dictionary<Seat, bool>();

            foreach (var seat in seats)
            {
                AreSeatsAvailable.Add(seat, seat.IsAvailable);
            }

            var viewModel = new BookSeatsViewModel()
            {
                Seats = seats.Count(),
                IsSeatAvailable = AreSeatsAvailable,
            };

            return this.View(viewModel);
        }
    }
}
