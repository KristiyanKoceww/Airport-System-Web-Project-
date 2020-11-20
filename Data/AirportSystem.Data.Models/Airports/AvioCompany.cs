namespace AirportSystem.Data.Models.Airports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Common.Models;
    using AirportSystem.Data.Planes;

    public class AvioCompany : BaseDeletableModel<int>
    {
        public AvioCompany()
        {
            this.Planes = new HashSet<Plane>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Plane> Planes { get; set; }
    }
}
