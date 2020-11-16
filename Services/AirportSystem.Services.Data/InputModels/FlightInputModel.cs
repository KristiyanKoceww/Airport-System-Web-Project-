namespace AirportSystem.Services.Data.InputModels
{
    using System;
    
    using AirportSystem.Data;

    public class FlightInputModel
    {
        public string From { get; set; }

        public string To { get; set; }

        public string AirportId { get; set; }

        public string PlaneId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public FlightStatus FlightStatus { get; set; }

        public TimeSpan FlightDuration { get; set; }
    }
}
