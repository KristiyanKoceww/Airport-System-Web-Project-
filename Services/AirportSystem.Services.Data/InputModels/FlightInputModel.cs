namespace AirportSystem.Services.Data.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Data.Planes;

    public class FlightInputModel
    {
        [Required]
        public int AirportId { get; set; }

        [Required]
        [MaxLength(30)]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Name must contains only letters")]
        public string AirportName { get; set; }

        public virtual Airport Airport { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "TravelLineCityId contains only digits!")]
        public int TravelLineCityId { get; set; }

        [Required]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Name must contains only letters")]
        public string TravelLineCityName { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "TravelLineCityId contains only digits!")]
        public int TravelLineCity2Id { get; set; }

        [Required]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Name must contains only letters")]
        public string TravelLineCity2Name { get; set; }

        public virtual TravelLine TravelLine { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "PlaneId contains only digits!")]
        public int PlaneId { get; set; }

        [Required]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "PlaneName must contains only letters")]
        public string PlaneName { get; set; }

        public virtual Plane Plane { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public FlightStatus FlightStatus { get; set; }

        public TimeSpan FlightDuration { get; set; }
    }
}
