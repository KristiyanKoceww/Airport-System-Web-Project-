namespace AirportSystem.Data.Planes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Common.Models;

    public class Plane : BaseDeletableModel<string>
    {
        public Plane()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public int Seats { get; set; }

        public bool IsPlaneAvailable { get; set; }

        [Required]
        public virtual PlaneType PlaneType { get; set; }
    }
}
