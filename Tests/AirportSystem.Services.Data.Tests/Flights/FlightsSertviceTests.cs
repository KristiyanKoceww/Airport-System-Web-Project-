namespace AirportSystem.Services.Data.Tests.Flights
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Data.Passengers;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.InputModels;
    using Xunit;

    public class FlightsSertviceTests : BaseServiceTests
    {
        [Fact]
        public async Task EnsureCreateFlightWorkProperly()
        {
            var service = new FlightService(this.DbContext);

            var city = new City()
            {
                Name = "Varna",
                Id = 22,
                CountryId = 1,
            };

            var city2 = new City()
            {
                Name = "Sofia",
                Id = 11,
                CountryId = 1,
            };

            var plane = new Plane()
            {
                Id = 2,
                Make = "Boeing",
                Model = "AirCraft",
                IsPlaneAvailable = true,
            };

            var flight1 = new FlightInputModel()
            {
                ArrivalTime = DateTime.UtcNow,
                DepartureTime = DateTime.UtcNow.AddHours(2),
                FlightDuration = TimeSpan.MinValue,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), "Ready"),
                PlaneId = plane.Id,
                Price = 233,
                TravelLineCityId = city.Id,
                TravelLineCity2Id = city2.Id,
                TravelLineCityName = city.Name,
                TravelLineCity2Name = city2.Name,
            };

            await this.DbContext.Planes.AddAsync(plane);
            await this.DbContext.Cities.AddAsync(city);
            await this.DbContext.Cities.AddAsync(city2);
            await this.DbContext.SaveChangesAsync();

            service.Create(flight1);

            var result = this.DbContext.Flights.Count();
            var expected = 1;
            Assert.Equal(expected, result);
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
        public void EnsureGetAllReturnZeroWhenDbIsEmpty()
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
            var result = service.SearchForFlight(origin, destination);

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
