namespace AirportSystem.Data.Destinations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CountryId { get; set; }

        public Country Country { get; set; }
    }
}
