namespace AirportSystem.Data.Planes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Common.Models;
    using AirportSystem.Data.Models.Planes;

    public class Plane : BaseDeletableModel<int>
    {
        public Plane()
        {
            this.Seats = new HashSet<Seat>();
        }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public int SeatsCount => this.Seats.Count;

        public bool IsPlaneAvailable { get; set; }

        public PlaneType PlaneType { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
