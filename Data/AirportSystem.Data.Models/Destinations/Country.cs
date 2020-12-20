namespace AirportSystem.Data.Models.Destinations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AirportSystem.Data.Common.Models;

    public class Country : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
