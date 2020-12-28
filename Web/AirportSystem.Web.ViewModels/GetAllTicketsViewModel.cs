namespace AirportSystem.Web.ViewModels
{
    using AirportSystem.Data.Tickets;
    using AirportSystem.Services.Mapping;

    public class GetAllTicketsViewModel : IMapFrom<Ticket>
    {
        public int Id { get; set; }

        public int PassengerId { get; set; }

        public string PassengerFirstName { get; set; }

        public string PassengerLastName { get; set; }

        public int LuggageId { get; set; }

        public decimal LuggageWeight { get; set; }

        public string SeatNumber { get; set; }

        public int FlightId { get; set; }

        public string FlightTravelLineCityName { get; set; }

        public string FlightTravelLineCity2Name { get; set; }

        public decimal FlightPrice { get; set; }

        public TicketType TicketType { get; set; }

        public TicketRule TicketRule { get; set; }
    }
}
