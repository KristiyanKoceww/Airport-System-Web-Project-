namespace AirportSystem.Services.Data.Flights
{
    using System.Collections.Generic;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;

    public interface IFlightService
    {
        void Create(FlightInputModel flightInputModel);

        Flight GetFlightById(string flightId);

        IEnumerable<Flight> GetAll();
    }
}
