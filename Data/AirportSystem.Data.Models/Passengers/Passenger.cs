namespace AirportSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Common.Models;
    using AirportSystem.Data.Passengers;
    using AirportSystem.Data.Tickets;

    public class Passenger : BaseDeletableModel<int>
    {
        public Passenger()
        {
            this.Luggage = new HashSet<Luggage>();
            this.Tickets = new HashSet<Ticket>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PassportId { get; set; }

        public virtual Passport Passport { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public virtual ICollection<Luggage> Luggage { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
