namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class TicketInputModel
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
        public string TicketType { get; set; }

        [Required]
        public string TicketRule { get; set; }
    }
}
