namespace AirportSystem.Services.Data.Passengers
{
    using System.Collections.Generic;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;

    public interface IPassengersService
    {
        void Create(PassengerInputModel passengerInputModel);

        Passenger GetPassengerById(string id);

        string GetPassengerId(string firstName, string middleName, string lastName);

        IEnumerable<Passenger> GetAllPassengersByFlightId(string flightId);

        IEnumerable<Passenger> GetAll();
    }
}
