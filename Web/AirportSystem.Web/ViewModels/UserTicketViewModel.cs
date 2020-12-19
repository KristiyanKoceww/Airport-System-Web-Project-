namespace AirportSystem.Web.ViewModels
{
    using System;

    using AirportSystem.Data.Tickets;
    using AirportSystem.Services.Mapping;

    public class UserTicketViewModel : IMapFrom<Ticket>
    {
        public int PassengerId { get; set; }

        public string PassengerName { get; set; }

        public int LuggageId { get; set; }

        public decimal Price { get; set; }

        public string SeatNumber { get; set; }

        public string LuggageType { get; set; }

        public decimal LuggageWeight { get; set; }

        public int FlightId { get; set; }

        public int TicketId { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime FlightDepartureTime { get; set; }

        public DateTime FlightArrivalTime { get; set; }

        public TicketType TicketType { get; set; }

        public TicketRule TicketRule { get; set; }
    }
}
