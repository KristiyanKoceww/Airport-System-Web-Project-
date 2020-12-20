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
        [Display(Name = "Please enter your travel id")]
        public string PassengerId { get; set; }

        [Required]
        [Display(Name = "Please enter your luggage id")]
        public string LuggageId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Please, choose your seat.")]
        public string SeatNumber { get; set; }

        [Required]
        [Display(Name = "Flight id")]
        public int FlightId { get; set; }

        [Required]
        [Display(Name = "Please choose your ticket type")]
        public TicketType TicketType { get; set; }

        [Required]
        [Display(Name = "Please choose your travel type")]
        public TicketRule TicketRule { get; set; }
    }
}
