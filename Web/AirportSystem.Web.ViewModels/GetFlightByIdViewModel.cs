namespace AirportSystem.Web.ViewModels
{
    using System;

    using AirportSystem.Data;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Mapping;

    public class GetFlightByIdViewModel : IMapFrom<Flight>
    {
        public int PlaneId { get; set; }

        public virtual Plane Plane { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public virtual FlightStatus FlightStatus { get; set; }

        public virtual TravelLine TravelLine { get; set; }

        public string TravelRoute { get; set; }

        public TimeSpan FlightDuration { get; set; }
    }
}
