namespace AirportSystem.Services.Data.Flights
{
    using System.Collections.Generic;

    using AirportSystem.Services.Data.InputModels;
    using PlaneSystem.Data.Flight;

    public interface IFlightService
    {
        void Create(FlightInputModel flightInputModel);

        Flight GetFlightById(string flightId);

        IEnumerable<Flight> GetAll();

    }
}
