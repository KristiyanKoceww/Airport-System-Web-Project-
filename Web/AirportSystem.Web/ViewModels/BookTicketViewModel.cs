namespace AirportSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data;
    using AirportSystem.Data.Tickets;

    public class BookTicketViewModel
    {
        [Required]
        public string PassengerId { get; set; }

        [Required]
        public string LuggageId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string SeatNumber { get; set; }

        [Required]
        public string FlightId { get; set; }

        [Required]
        public virtual TicketType TicketType { get; set; }

        [Required]
        public virtual TicketRule TicketRule { get; set; }
    }
}
