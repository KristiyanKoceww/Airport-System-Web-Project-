namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class TicketInputModel
    {
        [Required]
        public int PassengerId { get; set; }

        [Required]
        public int LuggageId { get; set; }

        [Required]
        public string SeatNumber { get; set; }

        [Required]
        public int FlightId { get; set; }

        [Required]
        public string TicketType { get; set; }

        [Required]
        public string TicketRule { get; set; }
    }
}
