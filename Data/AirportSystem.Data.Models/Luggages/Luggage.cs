namespace AirportSystem.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Common.Models;

    public class Luggage : BaseDeletableModel<int>
    {
        [Required]
        public virtual LuggageType LuggageType { get; set; }

        [Required]
        public int PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }

        [Required]
        public decimal Weight { get; set; }
    }
}
