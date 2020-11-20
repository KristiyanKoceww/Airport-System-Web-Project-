namespace AirportSystem.Data.Models.Destinations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
