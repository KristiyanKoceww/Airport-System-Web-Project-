namespace AirportSystem.Services.Data.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Models.Planes;

    public class TicketInputModel
    {
        [Required]
        public int PassengerId { get; set; }

        [Required]
        public int LuggageId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int SeatNumber { get; set; }

        [Required]
        public int FlightId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string TicketType { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string TicketRule { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
