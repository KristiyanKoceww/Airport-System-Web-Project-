namespace AirportSystem.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data.Passengers;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Passengers;
    using Xunit;

    public class PassengersServiceTests : BaseServiceTests
    {
        [Fact]
        public void EnsureCreatePassengerWorkProperly()
        {
            var service = new PassengersService(this.DbContext);

            var passenger = new PassengerInputModel()
            {
                FirstName = "Pesho",
                MiddleName = "Peshev",
                LastName = "Peshev",
                Address = "Sofia",
                Age = 25,
                Phone = "254655655",
                PassportId = "15552",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            service.Create(passenger);
            var passengers = this.DbContext.Passengers.Count();

            Assert.NotEqual(0, passengers);
            Assert.Equal(1, passengers);
        }

        [Fact]
        public void EnsureGetAllPassengerWorkProperly()
        {
            var service = new PassengersService(this.DbContext);

            var passenger = new PassengerInputModel()
            {
                FirstName = "Pesho",
                MiddleName = "Peshev",
                LastName = "Peshev",
                Address = "Sofia",
                Age = 25,
                Phone = "254655655",
                PassportId = "15552",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            var passenger2 = new PassengerInputModel()
            {
                FirstName = "Kiro",
                MiddleName = "Kiro",
                LastName = "Kiro",
                Address = "Varna",
                Age = 21,
                Phone = "2521155",
                PassportId = "1335552",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            service.Create(passenger);
            service.Create(passenger2);

            var passengers = service.GetAll().Count();
            var expected = this.DbContext.Passengers.Count();

            Assert.NotEqual(0, passengers);
            Assert.Equal(expected, passengers);
        }

        [Fact]
        public void EnsureGetAllPassengerReturnZeroWhenDbIsEmpty()
        {
            var service = new PassengersService(this.DbContext);
            var passengers = service.GetAll().Count();
            var expected = this.DbContext.Passengers.Count();

            Assert.Equal(expected, passengers);
        }

        [Fact]
        public void EnsureGetPassengerByIdWorkProperly()
        {
            var service = new PassengersService(this.DbContext);

            var passenger = new PassengerInputModel()
            {
                FirstName = "Pesho",
                MiddleName = "Peshev",
                LastName = "Peshev",
                Address = "Sofia",
                Age = 25,
                Phone = "254655655",
                PassportId = "15552",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            var passenger2 = new PassengerInputModel()
            {
                FirstName = "Kiro",
                MiddleName = "Kiro",
                LastName = "Kiro",
                Address = "Varna",
                Age = 21,
                Phone = "2521155",
                PassportId = "1335552",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            service.Create(passenger);
            service.Create(passenger2);
            var passengerById = service.GetPassengerById(1);

            var firstName = "Pesho";
            var middleName = "Peshev";
            var lastName = "Peshev";
            var phone = "254655655";

            Assert.Equal(firstName, passengerById.FirstName);
            Assert.Equal(middleName, passengerById.MiddleName);
            Assert.Equal(lastName, passengerById.LastName);
            Assert.Equal(phone, passengerById.Phone);
        }

        [Fact]
        public void EnsureGetPassengerByIdReturnNullWhenNoMatch()
        {
            var service = new PassengersService(this.DbContext);

            var passenger = new PassengerInputModel()
            {
                FirstName = "Pesho",
                MiddleName = "Peshev",
                LastName = "Peshev",
                Address = "Sofia",
                Age = 25,
                Phone = "254655655",
                PassportId = "15552",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            var passenger2 = new PassengerInputModel()
            {
                FirstName = "Kiro",
                MiddleName = "Kiro",
                LastName = "Kiro",
                Address = "Varna",
                Age = 21,
                Phone = "2521155",
                PassportId = "1335552",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            service.Create(passenger);
            service.Create(passenger2);
            var passengerById = service.GetPassengerById(3);

            Assert.Null(passengerById);
        }

        [Fact]
        public void EnsureGetPassengerByIdReturnNullWhenDbIsEmpty()
        {
            var service = new PassengersService(this.DbContext);

            var passengerById = service.GetPassengerById(1);

            Assert.Null(passengerById);
        }

        [Fact]
        public void EnsureGetPassengerByUserIdIsWorking()
        {
            var passengerService = new PassengersService(this.DbContext);
            var userPassengerService = new UserPassengersService(this.DbContext);

            var userId = "222";
            var passengerId = 1;

            userPassengerService.Create(userId, passengerId);

            var passengerByUserId = passengerService.GetPassengerByUserId(userId);

            Assert.Equal(userId, passengerByUserId.UserId);
            Assert.NotNull(passengerByUserId);
        }

        [Fact]
        public void EnsureGetPassengerByUserIdReturnNullWhenNoMatchAndDbIsEmpty()
        {
            var passengerService = new PassengersService(this.DbContext);

            var userIdToLookUp = "333";
            var passengerByUserId = passengerService.GetPassengerByUserId(userIdToLookUp);

            Assert.Null(passengerByUserId);
        }

        [Fact]
        public void EnsureGetPassengerIdIsWorkingCorrect()
        {
            var service = new PassengersService(this.DbContext);

            var passenger = new PassengerInputModel()
            {
                FirstName = "Pesho",
                MiddleName = "Peshev",
                LastName = "Peshev",
                Address = "Sofia",
                Age = 25,
                Phone = "254655655",
                PassportId = "15552",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            var passenger2 = new PassengerInputModel()
            {
                FirstName = "Kiro",
                MiddleName = "Kiro",
                LastName = "Kiro",
                Address = "Varna",
                Age = 21,
                Phone = "2521155",
                PassportId = "1335552",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            service.Create(passenger);
            service.Create(passenger2);

            var passengerId = service.GetPassengerId(passenger.FirstName, passenger.MiddleName, passenger.LastName);

            var passenger2Id = service.GetPassengerId(passenger2.FirstName, passenger2.MiddleName, passenger2.LastName);

            var expectedId = 1;
            var expectedId2 = 2;
            Assert.Equal(expectedId, passengerId);
            Assert.Equal(expectedId2, passenger2Id);
        }

        [Fact]
        public void EnsureGetPassengerIdReturnNullWhenNoMatch()
        {
            var service = new PassengersService(this.DbContext);

            var passenger = new PassengerInputModel()
            {
                FirstName = "Kiro",
                MiddleName = "Kiro",
                LastName = "Kiro",
                Address = "Varna",
                Age = 21,
                Phone = "2521155",
                PassportId = "1335552",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            service.Create(passenger);
            var lastName = "Kirov";

            var passengerId = service.GetPassengerId(passenger.FirstName, passenger.MiddleName, lastName);

            Assert.Equal(0, passengerId);
        }
    }
}
