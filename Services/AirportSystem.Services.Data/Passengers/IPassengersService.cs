namespace AirportSystem.Services.Data.Passengers
{
    using System.Collections.Generic;

    using AirportSystem.Services.Data.InputModels;
    using PlaneSystem.Data;

    public interface IPassengersService
    {
        void Create(PassengerInputModel passengerInputModel);

        Passenger GetPassengerById(string id);

        string GetPassengerId(string firstName, string middleName, string lastName);

        IEnumerable<Passenger> GetAllPassengersByFlightId(string flightId);

        IEnumerable<Passenger> GetAll();
    }
}
