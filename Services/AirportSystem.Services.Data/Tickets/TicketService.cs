namespace AirportSystem.Services.Data.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;
    using PlaneSystem.Data.Tickets;

    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext db;

        public TicketService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(TicketInputModel ticketInputModel)
        {
            var ticket = new Ticket()
            {
                FlightId = ticketInputModel.FlightId,
                LuggageId = ticketInputModel.LuggageId,
                PassengerId = ticketInputModel.PassengerId,
                Price = ticketInputModel.Price,
                SeatNumber = ticketInputModel.SeatNumber,
                TicketRule = (TicketRule)Enum.Parse(typeof(TicketRule), ticketInputModel.TicketRule),
                TicketType = (TicketType)Enum.Parse(typeof(TicketType), ticketInputModel.TicketType),
            };

            this.db.Tickets.Add(ticket);
            this.db.SaveChanges();
        }

        public IEnumerable<Ticket> GetAll()
        {
            var tickets = this.db.Tickets.Select(x => new Ticket()
            {
                FlightId = x.FlightId,
                LuggageId = x.LuggageId,
                PassengerId = x.PassengerId,
                Price = x.Price,
                SeatNumber = x.SeatNumber,
                TicketRule = x.TicketRule,
                TicketType = x.TicketType,
            }).ToList();

            return tickets;
        }

        public IEnumerable<Ticket> GetAllByFlightId(string flightId)
        {
            var tickets = this.db.Tickets.Where(x => x.Flight.Id == flightId).Select(x => new Ticket()
            {
                FlightId = x.FlightId,
                LuggageId = x.LuggageId,
                PassengerId = x.PassengerId,
                Price = x.Price,
                SeatNumber = x.SeatNumber,
                TicketRule = x.TicketRule,
                TicketType = x.TicketType,
            }).ToList();

            return tickets;
        }

        public Ticket GetTicketByPassengerId(string passengerId)
        {
            var ticket = this.db.Tickets.Where(x => x.PassengerId == passengerId).Select(x => new Ticket()
            {
                FlightId = x.FlightId,
                LuggageId = x.LuggageId,
                PassengerId = x.PassengerId,
                Price = x.Price,
                SeatNumber = x.SeatNumber,
                TicketRule = x.TicketRule,
                TicketType = x.TicketType,
            }).FirstOrDefault();

            return ticket;
        }
    }
}
