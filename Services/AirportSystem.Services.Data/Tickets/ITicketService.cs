namespace AirportSystem.Services.Data.Tickets
{
    using System.Collections.Generic;

    using AirportSystem.Data.Tickets;
    using AirportSystem.Services.Data.InputModels;

    public interface ITicketService
    {
        void Create(TicketInputModel ticketInputModel);

        Ticket GetTicketByPassengerId(string passengerId);

        IEnumerable<Ticket> GetAllByFlightId(string flightId);

        IEnumerable<Ticket> GetAll();
    }
}
