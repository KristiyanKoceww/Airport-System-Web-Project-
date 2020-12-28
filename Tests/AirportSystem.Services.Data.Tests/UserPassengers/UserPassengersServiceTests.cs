namespace AirportSystem.Services.Data.Tests.UserPassengers
{
    using System.Linq;

    using AirportSystem.Data.Models.Passengers;
    using Xunit;

    public class UserPassengersServiceTests : BaseServiceTests
    {
        [Fact]
        public void EnsureCreateWorkProperly()
        {
            var service = new UserPassengersService(this.DbContext);

            var userId = "123";
            var passengerId = 1;

            var userId2 = "12345";
            var passengerId2 = 2;

            service.Create(userId, passengerId);
            service.Create(userId2, passengerId2);

            var expectedCount = 2;
            var actualCount = this.DbContext.UsersPassengers.Count();

            Assert.Equal(expectedCount, actualCount);
        }
    }
}
