namespace AirportSystem.Services.Data.Passengers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Passengers;
    using AirportSystem.Services.Data.InputModels;

    public interface IPassengersService
    {
        void Create(PassengerInputModel passengerInputModel);

        Passenger GetPassengerById(int id);

        UserPassenger GetPassengerByUserId(string id);

        int GetPassengerId(string firstName, string middleName, string lastName);

        IEnumerable<Passenger> GetAll();
    }
}
