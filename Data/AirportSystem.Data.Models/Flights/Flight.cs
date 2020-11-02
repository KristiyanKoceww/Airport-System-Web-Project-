namespace PlaneSystem.Data.Flight
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    using AirportSystem.Data.Models.Flights;
    using PlaneSystem.Data.Planes;

    public class Flight
    {
        public Flight()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Passengers = new HashSet<Passenger>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string PlaneId { get; set; }

        public virtual Plane Plane { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        [Required]
        public virtual FlightStatus FlightStatus { get; set; }

        public virtual TravelLine TravelLine { get; set; }

        public string TravelRoute => this.TravelLine.CityId + "-" + this.TravelLine.City2Id;

        public DateTime FlightDuration { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }

        public int FreeSeats => this.Plane.Seats - this.Passengers.Count();

        public int UsedSeats => this.Passengers.Count();
    }
}
