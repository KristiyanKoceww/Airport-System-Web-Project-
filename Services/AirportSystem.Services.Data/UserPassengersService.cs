namespace AirportSystem.Services.Data
{
    using AirportSystem.Data;
    using AirportSystem.Data.Models.Passengers;

    public class UserPassengersService : IUserPassengersService
    {
        private readonly ApplicationDbContext db;

        public UserPassengersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string userId, string passengerId)
        {
            var userPassenger = new UserPassenger()
            {
                PassengerId = passengerId,
                UserId = userId,
            };

            this.db.UsersPassengers.Add(userPassenger);
            this.db.SaveChanges();
        }
    }
}
