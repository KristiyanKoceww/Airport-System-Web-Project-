namespace PlaneSystem.Data.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using PlaneSystem.Data.Flight;

    public class Ticket
    {
        public Ticket()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }

        public string LuggageId { get; set; }

        public virtual Luggage Luggage { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string SeatNumber { get; set; }

        [Required]
        public string FlightId { get; set; }

        public Flight Flight { get; set; }

        [Required]
        public virtual TicketType TicketType { get; set; }

        [Required]
        public virtual TicketRule TicketRule { get; set; }
    }
}
