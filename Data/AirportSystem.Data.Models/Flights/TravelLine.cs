namespace AirportSystem.Data.Models.Flights
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using PlaneSystem.Data.Destinations;

    public class TravelLine
    {
        [Required]
        public string CityId { get; set; }

        [Required]
        public string City2Id { get; set; }

        public City City { get; set; }
    }
}
