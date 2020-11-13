namespace AirportSystem.Data.Models.Airports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Common.Models;
    using AirportSystem.Data.Planes;

    public class AvioCompany : BaseDeletableModel<string>
    {
        public AvioCompany()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Planes = new HashSet<Plane>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Plane> Planes { get; set; }
    }
}
