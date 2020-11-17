namespace AirportSystem.Services.Data.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data;

    public class FlightInputModel
    {
        [Required]
        [MaxLength(30)]
        public string From { get; set; }

        [Required]
        [MaxLength(30)]
        public string To { get; set; }

        [Required]
        public string AirportId { get; set; }

        [Required]
        public string PlaneId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public FlightStatus FlightStatus { get; set; }

        public TimeSpan FlightDuration { get; set; }
    }
}
