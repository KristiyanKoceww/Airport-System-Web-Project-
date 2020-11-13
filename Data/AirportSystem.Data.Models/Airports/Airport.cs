namespace AirportSystem.Data.Models.Airports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data;
    using AirportSystem.Data.Common.Models;
    using AirportSystem.Data.Destinations;

    public class Airport : BaseDeletableModel<string>
    {
        public Airport()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Flights = new HashSet<Flight>();
            this.AvioCompanies = new HashSet<AvioCompany>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public virtual ICollection<AvioCompany> AvioCompanies { get; set; }
    }
}
