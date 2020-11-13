namespace AirportSystem.Data.Destinations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Country()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
