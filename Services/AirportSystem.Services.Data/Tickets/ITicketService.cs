namespace AirportSystem.Services.Data.Tickets
{
    using System.Collections.Generic;
    using AirportSystem.Data;
    using AirportSystem.Data.Tickets;
    using AirportSystem.Services.Data.InputModels;

    public interface ITicketService
    {
        Ticket Create(TicketInputModel ticketInputModel);

        Ticket GetTicketByPassengerId(int passengerId);

        Ticket GetTicketById(int id);

        IEnumerable<Ticket> GetAllByFlightId(int flightId);

        IEnumerable<Ticket> GetAll();

        decimal CalculatePrice(decimal price, string ticketRule, string ticketType);
    }
}
