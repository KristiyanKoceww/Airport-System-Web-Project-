namespace AirportSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AirportSystem.Data.Common.Models;
    using AirportSystem.Data.Planes;

    public class Flight : BaseDeletableModel<int>
    {

        [Required]
        public int PlaneId { get; set; }

        public virtual Plane Plane { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        [Required]
        public virtual FlightStatus FlightStatus { get; set; }

        public int TravelLineCityId { get; set; }

        public string TravelLineCityName { get; set; }

        public int TravelLineCity2Id { get; set; }

        public string TravelLineCity2Name { get; set; }

        public virtual TravelLine TravelLine { get; set; }

        public decimal Price { get; set; }

        public TimeSpan FlightDuration { get; set; }
    }
}
