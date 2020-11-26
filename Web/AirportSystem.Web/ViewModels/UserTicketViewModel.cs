using AirportSystem.Data.Tickets;
using AirportSystem.Services.Mapping;
using System;

namespace AirportSystem.Web.ViewModels
{
    public class UserTicketViewModel : IMapFrom<Ticket>
    {
        public int PassengerId { get; set; }

        public string PassengerName { get; set; }

        public int LuggageId { get; set; }

        public decimal Price { get; set; }

        public string SeatNumber { get; set; }

        public int FlightId { get; set; }

        public string FlightTravelRoute { get; set; }

        public DateTime FlightDepartureTime { get; set; }

        public DateTime FlightArrivalTime { get; set; }

        public TicketType TicketType { get; set; }

        public TicketRule TicketRule { get; set; }
    }
}
