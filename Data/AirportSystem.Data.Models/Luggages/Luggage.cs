﻿namespace PlaneSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Luggage
    {
        public Luggage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public virtual LuggageType LuggageType { get; set; }

        [Required]
        public string PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }

        [Required]
        public decimal Weight { get; set; }
    }
}
