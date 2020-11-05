namespace AirportSystem.Services.Data.InputModels
{
    public class TicketInputModel
    {
        public string PassengerId { get; set; }

        public string LuggageId { get; set; }

        public decimal Price { get; set; }

        public string SeatNumber { get; set; }

        public string FlightId { get; set; }

        public string TicketType { get; set; }

        public string TicketRule { get; set; }
    }
}
