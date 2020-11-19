namespace AirportSystem.Data.Models.Destinations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Common.Models;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
