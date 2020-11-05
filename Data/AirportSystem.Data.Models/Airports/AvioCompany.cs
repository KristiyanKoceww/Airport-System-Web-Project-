namespace AirportSystem.Data.Models.Airports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PlaneSystem.Data.Planes;

    public class AvioCompany
    {
        public AvioCompany()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Planes = new HashSet<Plane>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Plane> Planes { get; set; }
    }
}
