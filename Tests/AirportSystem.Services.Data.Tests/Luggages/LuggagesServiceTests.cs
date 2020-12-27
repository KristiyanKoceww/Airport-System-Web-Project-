using AirportSystem.Data;
using AirportSystem.Services.Data.InputModels;
using AirportSystem.Services.Data.Luggages;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AirportSystem.Services.Data.Tests.Luggages
{
    public class LuggagesServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task EnsureCreateWorkProperly()
        {
            var service = new LuggageService(this.DbContext);

            var luggage = new LuggageInputModel()
            {
                PassengerFirstName = "Pesho",
                Weight = 10,
                PassengerId = 1,
                LuggageType = "CarryOnBag",
            };

            service.Create(luggage);
            var expectedCount = 1;
            var result = this.DbContext.Luggage.Count();

            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public async Task EnsureGetLuggageByIdIsWorking()
        {
            var service = new LuggageService(this.DbContext);

            var luggage = new LuggageInputModel()
            {
                PassengerFirstName = "Pesho",
                Weight = 10,
                PassengerId = 1,
                LuggageType = "CarryOnBag",
            };

            service.Create(luggage);
            
            var expected = 1;
            var result = service.GetLuggageById(1);

            Assert.Equal(expected, result.Id);
        }

        [Fact]
        public async Task EnsureGetLuggageByIdReturnNullWhenThereIsNoMatch()
        {
            var service = new LuggageService(this.DbContext);

            var luggage = new LuggageInputModel()
            {
                PassengerFirstName = "Pesho",
                Weight = 10,
                PassengerId = 1,
                LuggageType = "CarryOnBag",
            };

            service.Create(luggage);

            var result = service.GetLuggageById(10);

            Assert.Null(result);
        }

        [Fact]
        public async Task EnsureGetLuggageByPassengerIdWorkProperly()
        {
            var service = new LuggageService(this.DbContext);

            var luggage = new LuggageInputModel()
            {
                PassengerFirstName = "Pesho",
                Weight = 10,
                PassengerId = 1,
                LuggageType = "CarryOnBag",
            };

            service.Create(luggage);

            var passengerId = 1;
            var passengersLuggage = service.GetLuggageByPassengerId(passengerId);

            Assert.NotNull(passengersLuggage);
        }

        [Fact]
        public async Task EnsureGetLuggageByPassengerIdReturnNullWHenNoMatch()
        {
            var service = new LuggageService(this.DbContext);

            var luggage = new LuggageInputModel()
            {
                PassengerFirstName = "Pesho",
                Weight = 10,
                PassengerId = 1,
                LuggageType = "CarryOnBag",
            };

            service.Create(luggage);
            var passengerId = 2;
            var passengersLuggage = service.GetLuggageByPassengerId(passengerId);

            Assert.Null(passengersLuggage);
        }
    }
}
