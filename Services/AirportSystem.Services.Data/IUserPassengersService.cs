namespace AirportSystem.Services.Data
{
    public interface IUserPassengersService
    {
        void Create(string userId, int passengerId);
    }
}
