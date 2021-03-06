﻿namespace AirportSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Data.Planes;

    public class AddFlightViewModel
    {
        public int AirportId { get; set; }

        public string AirportName { get; set; }

        public virtual Airport Airport { get; set; }

        public int TravelLineCityId { get; set; }

        public string TravelLineCityName { get; set; }

        public int TravelLineCity2Id { get; set; }

        public string TravelLineCity2Name { get; set; }

        public virtual TravelLine TravelLine { get; set; }

        public IEnumerable<TravelLine> TravelLines { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int PlaneId { get; set; }

        public string PlaneName { get; set; }

        public virtual Plane Plane { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public FlightStatus FlightStatus { get; set; }

        public TimeSpan FlightDuration { get; set; }
    }
}
