namespace AirportSystem.Services.Data.Tickets
{
    using System.Collections.Generic;

    using AirportSystem.Services.Data.InputModels;
    using PlaneSystem.Data.Tickets;

    public interface ITicketService
    {
        void Create(TicketInputModel ticketInputModel);

        Ticket GetTicketByPassengerId(string passengerId);

        IEnumerable<Ticket> GetAllByFlightId(string flightId);

        IEnumerable<Ticket> GetAll();
    }
}
