namespace AirportSystem.Data.Models.Airports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PlaneSystem.Data.Destinations;
    using PlaneSystem.Data.Flight;

    public class Airport
    {
        public Airport()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Flights = new HashSet<Flight>();
            this.AvioCompanies = new HashSet<AvioCompany>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public virtual ICollection<AvioCompany> AvioCompanies { get; set; }
    }
}
