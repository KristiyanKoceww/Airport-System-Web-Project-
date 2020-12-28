namespace AirportSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Mapping;

    public class AllFlightsViewModel : IMapFrom<Flight>
    {
        public int Id { get; set; }

        public int PlaneId { get; set; }

        public string PlaneName { get; set; }

        public int PlaneSeatsCount { get; set; }

        public int FreeSeats { get; set; }

        public virtual Plane Plane { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public virtual FlightStatus FlightStatus { get; set; }

        public decimal Price { get; set; }

        public string TravelLineCityName { get; set; }

        public string TravelLineCity2Name { get; set; }

        public virtual TravelLine TravelLine { get; set; }

        public TimeSpan FlightDuration { get; set; }
    }
}
