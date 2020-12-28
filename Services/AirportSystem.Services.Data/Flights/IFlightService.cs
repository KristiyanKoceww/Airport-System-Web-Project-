namespace AirportSystem.Services.Data.Flights
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

    public interface IFlightService
    {
        void Create(FlightInputModel flightInputModel);

        void Remove(Flight flight);

        IEnumerable<Flight> FlightsByDestination(string destination);

        Flight GetFlightById(int flightId);

        IEnumerable<AllFlightsViewModel> GetAll();

        IEnumerable<Flight> SearchForFlight(string origin, string destination);
    }
}
