namespace AirportSystem.Data.Models.Destinations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Images = new HashSet<Image>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public string OriginalUrl { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
