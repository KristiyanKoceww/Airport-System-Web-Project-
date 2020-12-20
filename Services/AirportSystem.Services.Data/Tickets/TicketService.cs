namespace AirportSystem.Services.Data.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Tickets;
    using AirportSystem.Services.Data.InputModels;

    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext db;

        public TicketService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(TicketInputModel ticketInputModel, int flightId)
        {
            var ticket = new Ticket()
            {
                LuggageId = ticketInputModel.LuggageId,
                PassengerId = ticketInputModel.PassengerId,
                SeatNumber = ticketInputModel.SeatNumber,
                TicketRule = (TicketRule)Enum.Parse(typeof(TicketRule), ticketInputModel.TicketRule),
                TicketType = (TicketType)Enum.Parse(typeof(TicketType), ticketInputModel.TicketType),
            };

            ticket.FlightId = flightId;

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
                SeatNumber = x.SeatNumber,
                TicketRule = x.TicketRule,
                TicketType = x.TicketType,
            }).ToList();

            return tickets;
        }

        public IEnumerable<Ticket> GetAllByFlightId(int flightId)
        {
            var tickets = this.db.Tickets.Where(x => x.Flight.Id == flightId).Select(x => new Ticket()
            {
                FlightId = x.FlightId,
                LuggageId = x.LuggageId,
                PassengerId = x.PassengerId,
                SeatNumber = x.SeatNumber,
                TicketRule = x.TicketRule,
                TicketType = x.TicketType,
            }).ToList();

            return tickets;
        }

        public int GetTicketByFlightId(int id)
        {
            var ticketId = this.db.Tickets.Where(x => x.FlightId == id).Select(x => x.Id).FirstOrDefault();

            return ticketId;
        }

        public Ticket GetTicketById(int id)
        {
            var ticket = this.db.Tickets.Where(x => x.Id == id).FirstOrDefault();
            return ticket;
        }

        public Ticket GetTicketByPassengerId(int passengerId)
        {
            var ticket = this.db.Tickets.Where(x => x.PassengerId == passengerId).Select(x => new Ticket()
            {
                FlightId = x.FlightId,
                LuggageId = x.LuggageId,
                PassengerId = x.PassengerId,
                SeatNumber = x.SeatNumber,
                TicketRule = x.TicketRule,
                TicketType = x.TicketType,
            }).FirstOrDefault();

            return ticket;
        }
    }
}
