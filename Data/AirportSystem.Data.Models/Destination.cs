namespace PlaneSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using PlaneSystem.Data.Destinations;

    public class Destination
    {
        [Required]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        public string CityId { get; set; }

        public virtual City City { get; set; }
    }
}
