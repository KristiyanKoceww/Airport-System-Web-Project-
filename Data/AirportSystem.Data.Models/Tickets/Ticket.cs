namespace AirportSystem.Data.Tickets
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data;
    using AirportSystem.Data.Common.Models;

    public class Ticket : BaseDeletableModel<int>
    {

        [Required]
        public int PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }

        public int LuggageId { get; set; }

        public virtual Luggage Luggage { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string SeatNumber { get; set; }

        [Required]
        public int FlightId { get; set; }

        public virtual Flight Flight { get; set; }

        [Required]
        public virtual TicketType TicketType { get; set; }

        [Required]
        public virtual TicketRule TicketRule { get; set; }
    }
}
