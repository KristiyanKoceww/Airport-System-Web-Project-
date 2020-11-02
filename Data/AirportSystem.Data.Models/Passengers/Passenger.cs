namespace PlaneSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using AirportSystem.Data.Models;
    using PlaneSystem.Data.Passengers;
    using PlaneSystem.Data.Tickets;

    public class Passenger
    {
        public Passenger()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Luggage = new HashSet<Luggage>();
            this.Tickets = new HashSet<Ticket>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PassportId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Passport Passport { get; set; }

        [Required]
        public virtual PassengerType PassengerType { get; set; }

        [Required]
        public virtual Gender Gender { get; set; }

        public virtual ICollection<Luggage> Luggage { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
