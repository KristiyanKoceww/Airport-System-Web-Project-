namespace AirportSystem.Services.Data.Flights
{
    using System.Collections.Generic;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

    public interface IFlightService
    {
        void Create(FlightInputModel flightInputModel);

        Flight GetFlightById(int flightId);

        IEnumerable<AllFlightsViewModel> GetAll();

    }
}
