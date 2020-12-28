namespace AirportSystem.Services.Data.Tests.Flights
{
    using AirportSystem.Data;
    using AirportSystem.Data.Passengers;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Mapping;
    using AirportSystem.Web.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class FlightsSertviceTests : BaseServiceTests
    {
        [Fact]
        public async Task EnsureCreateFlightWorkProperly()
        {
            var service = new FlightService(this.DbContext);

            var flight = new Flight()
            {
                Id = 1,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MinValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            var flight2 = new FlightInputModel()
            {
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MinValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            var flight1 = new FlightInputModel()
            {
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MinValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 12,
                Price = 233,
                TravelLineCityId = 22,
                TravelLineCity2Id = 11,
                TravelLineCityName = "Varna",
                TravelLineCity2Name = "Sofia",
            };

            service.Create(flight2);
            service.Create(flight1);

            var result = this.DbContext.Flights.Count();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task EnsureAddPassengerToFlightWorkProperly()
        {
            var service = new FlightService(this.DbContext);

            var flight = new Flight()
            {
                Id = 1,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            var passenger = new Passenger()
            {
                FirstName = "Kris",
                MiddleName = "Kris",
                LastName = "Kris",
                Phone = "084556",
                Address = "sofia",
                Age = 25,
                Id = 2,
                PassportId = "21515",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            var passenger2 = new Passenger()
            {
                FirstName = "Pesho",
                MiddleName = "Pesho",
                LastName = "Pesho",
                Phone = "084151251556",
                Address = "varna",
                Age = 22,
                Id = 3,
                PassportId = "2111515",
                Gender = (Gender)Enum.Parse(typeof(Gender), "Male"),
            };

            await this.DbContext.Flights.AddAsync(flight);
            await this.DbContext.Passengers.AddAsync(passenger);
            await this.DbContext.Passengers.AddAsync(passenger2);
            await this.DbContext.SaveChangesAsync();

            service.AddPassengerToFlight(flight, passenger);
            service.AddPassengerToFlight(flight, passenger2);

            var flightDb = this.DbContext.Flights.Find(1);
            var result = flightDb.Passengers.Count();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task EnsureFindFlightByDestinationWorkProperly()
        {
            var service = new FlightService(this.DbContext);

            var flight = new Flight()
            {
                Id = 1,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            await this.DbContext.Flights.AddAsync(flight);
            await this.DbContext.SaveChangesAsync();

            var result = service.FlightsByDestination("Varna");
            var fligh = result.FirstOrDefault();

            Assert.Equal("Varna", fligh.TravelLineCity2Name);
        }

        [Fact]
        public async Task EnsureFindFlightByDestinationReturnZeroFlights()
        {
            var service = new FlightService(this.DbContext);

            var flight = new Flight()
            {
                Id = 1,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Plovdiv",
            };

            await this.DbContext.Flights.AddAsync(flight);
            await this.DbContext.SaveChangesAsync();

            var result = service.FlightsByDestination("Varna");

            Assert.Empty(result);
        }

        [Fact]
        public async Task EnsureFindFlightByDestinationReturnMoreThan1Flight()
        {
            var service = new FlightService(this.DbContext);

            var flight = new Flight()
            {
                Id = 1,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            var flight2 = new Flight()
            {
                Id = 2,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            await this.DbContext.Flights.AddAsync(flight);
            await this.DbContext.Flights.AddAsync(flight2);
            await this.DbContext.SaveChangesAsync();

            var result = service.FlightsByDestination("Varna");

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task EnsureGetAllReturnZeroWhenDbIsEmpty()
        {
            var service = new FlightService(this.DbContext);

            var result = service.GetAll();

            Assert.Empty(result);
        }

        [Fact]
        public async Task EnsureFindFlightByIdWorkProperly()
        {
            var service = new FlightService(this.DbContext);

            var flight = new Flight()
            {
                Id = 1,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            await this.DbContext.Flights.AddAsync(flight);
            await this.DbContext.SaveChangesAsync();

            var result = service.GetFlightById(1);

            Assert.Equal(1, result.Id);
            Assert.Equal("Sofia", result.TravelLineCityName);
            Assert.Equal("Varna", result.TravelLineCity2Name);
        }

        [Fact]
        public async Task EnsureFindFlightByIdReturnNullWhenThereIsNoMatch()
        {
            var service = new FlightService(this.DbContext);

            var flight = new Flight()
            {
                Id = 1,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            await this.DbContext.Flights.AddAsync(flight);
            await this.DbContext.SaveChangesAsync();

            var result = service.GetFlightById(2);

            Assert.Null(result);
        }

        [Fact]
        public async Task EnsureRemoveWorkProperly()
        {
            var service = new FlightService(this.DbContext);

            var flight = new Flight()
            {
                Id = 1,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            await this.DbContext.Flights.AddAsync(flight);
            await this.DbContext.SaveChangesAsync();

            var result = service.GetFlightById(1);
            service.Remove(result);
            Assert.True(result.IsDeleted);
        }


        [Fact]
        public async Task EnsureSearchForFlightWorkProperly()
        {
            var service = new FlightService(this.DbContext);

            var flight = new Flight()
            {
                Id = 1,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            var flight2 = new Flight()
            {
                Id = 3,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            await this.DbContext.Flights.AddAsync(flight);
            await this.DbContext.Flights.AddAsync(flight2);
            await this.DbContext.SaveChangesAsync();

            var origin = "Sofia";
            var destination = "Varna";
            var result = service.SearchForFlight(origin,destination);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task EnsureSearchForFlightReturnZeroWhenThereIsNotMatch()
        {
            var service = new FlightService(this.DbContext);

            var flight = new Flight()
            {
                Id = 1,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            var flight2 = new Flight()
            {
                Id = 3,
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MaxValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = 2,
                Price = 200,
                TravelLineCityId = 2,
                TravelLineCity2Id = 1,
                TravelLineCityName = "Sofia",
                TravelLineCity2Name = "Varna",
            };

            await this.DbContext.Flights.AddAsync(flight);
            await this.DbContext.Flights.AddAsync(flight2);
            await this.DbContext.SaveChangesAsync();

            var origin = "Sofia1";
            var destination = "Varna1";
            var result = service.SearchForFlight(origin, destination);

            Assert.Empty(result);
        }
    }
}
