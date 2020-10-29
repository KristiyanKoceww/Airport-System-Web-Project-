namespace PlaneSystem.Data.Planes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Plane
    {
        public Plane()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Model { get; set; }

        public int Seats { get; set; }

        public int Range { get; set; }

        [Required]
        public virtual PlaneType PlaneType { get; set; }
    }
}
