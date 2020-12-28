namespace AirportSystem.Services.Data.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Tickets;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext db;

        public TicketService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public decimal CalculatePrice(decimal price, string ticketRule, string ticketType)
        {
            if (ticketRule == "2")
            {
                price *= 2;
            }

            switch (ticketType)
            {
                case "1":
                    price -= price * 0.2M;
                    break;
                case "2":
                    price *= 1.5M;
                    break;
                case "3":
                    price = 1.25M;
                    break;
            }

            return price;
        }

        public Ticket Create(TicketInputModel ticketInputModel)
        {
            var ticket = new Ticket()
            {
                LuggageId = ticketInputModel.LuggageId,
                PassengerId = ticketInputModel.PassengerId,
                SeatNumber = ticketInputModel.SeatNumber.ToString(),
                TicketRule = (TicketRule)Enum.Parse(typeof(TicketRule), ticketInputModel.TicketRule),
                TicketType = (TicketType)Enum.Parse(typeof(TicketType), ticketInputModel.TicketType),
            };

            ticket.FlightId = ticketInputModel.FlightId;

            this.db.Tickets.Add(ticket);
            this.db.SaveChanges();

            return ticket;
        }

        public IEnumerable<GetAllTicketsViewModel> GetAll()
        {
            var tickets = this.db.Tickets.Select(x => new GetAllTicketsViewModel()
            {
                Id = x.Id,
                FlightId = x.FlightId,
                LuggageId = x.LuggageId,
                PassengerId = x.PassengerId,
                SeatNumber = x.SeatNumber,
                TicketRule = x.TicketRule,
                TicketType = x.TicketType,
                FlightPrice = x.Flight.Price,
                FlightTravelLineCity2Name = x.Flight.TravelLineCity2Name,
                FlightTravelLineCityName = x.Flight.TravelLineCityName,
                PassengerFirstName = x.Passenger.FirstName,
                PassengerLastName = x.Passenger.LastName,
                LuggageWeight = x.Luggage.Weight,
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
