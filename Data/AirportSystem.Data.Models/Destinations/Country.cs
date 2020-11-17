namespace AirportSystem.Data.Models.Destinations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AirportSystem.Data.Common.Models;

    public class Country : BaseDeletableModel<int>
    {
        public Country()
        {

        }

        [Required]
        public string Name { get; set; }
    }
}
