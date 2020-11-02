namespace AirportSystem.Services.Data.Passengers
{
    using AirportSystem.Services.Data.InputModels;
    using PlaneSystem.Data;

    public interface IPassengersService
    {
        void Create(PassengerInputModel passengerInputModel);

        Passenger GetPassengerById(string id);

        string GetPassengerId(string firstName, string middleName, string lastName);
    }
}
