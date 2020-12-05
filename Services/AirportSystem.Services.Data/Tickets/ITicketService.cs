namespace AirportSystem.Services.Data.Tickets
{
    using System.Collections.Generic;

    using AirportSystem.Data.Tickets;
    using AirportSystem.Services.Data.InputModels;

    public interface ITicketService
    {
        void Create(TicketInputModel ticketInputModel, int flightId);

        Ticket GetTicketByPassengerId(int passengerId);

        Ticket GetTicketById(int id);

        int GetTicketByFlightId(int id);

        IEnumerable<Ticket> GetAllByFlightId(int flightId);

        IEnumerable<Ticket> GetAll();
    }
}
