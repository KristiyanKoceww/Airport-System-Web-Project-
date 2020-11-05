namespace AirportSystem.Services.Data.InputModels
{
    using System;

    public class FlightInputModel
    {
        public string PlaneId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string FlightStatus { get; set; }

        public DateTime FlightDuration { get; set; }
    }
}
