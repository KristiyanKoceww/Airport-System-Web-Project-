namespace AirportSystem.Web.ViewModels
{
    using System;

    using AirportSystem.Data;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Mapping;

    public class GetFlightByIdViewModel : IMapFrom<Flight>
    {
        public int Id { get; set; }

        public int PlaneId { get; set; }

        public virtual Plane Plane { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public FlightStatus FlightStatus { get; set; }

        public int TravelLineCityId { get; set; }

        public string TravelLineCityName { get; set; }

        public int TravelLineCity2Id { get; set; }

        public string TravelLineCity2Name { get; set; }

        public virtual TravelLine TravelLine { get; set; }

        public TimeSpan FlightDuration { get; set; }

        public decimal Price { get; set; }
    }
}
