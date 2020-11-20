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
        public Flight()
        {
            this.Passengers = new HashSet<Passenger>();
        }

        [Required]
        public int PlaneId { get; set; }

        public virtual Plane Plane { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        [Required]
        public virtual FlightStatus FlightStatus { get; set; }

        public virtual TravelLine TravelLine { get; set; }

        public string TravelRoute { get; set; }

        public TimeSpan FlightDuration { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }

        public int FreeSeats => this.Plane.Seats - this.Passengers.Count();

    }
}
