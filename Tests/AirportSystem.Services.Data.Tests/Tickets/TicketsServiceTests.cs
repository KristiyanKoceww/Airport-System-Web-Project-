namespace AirportSystem.Services.Data.Tests.Tickets
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data;
    using AirportSystem.Data.Tickets;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Tickets;
    using Xunit;

    public class TicketsServiceTests : BaseServiceTests
    {
        [Fact]
        public void EnsureCreateTicketWorkProperly()
        {
            var service = new TicketService(this.DbContext);

            var ticketModel = new TicketInputModel()
            {
                LuggageId = 1,
                PassengerId = 1,
                SeatNumber = 12,
                TicketRule = "RoundTrip",
                TicketType = "Economy",
                FlightId = 1,
            };

            var ticket = service.Create(ticketModel);

            var expectedCount = 1;
            var actual = this.DbContext.Tickets.Count();

            Assert.Equal(expectedCount, actual);
        }

        [Fact]
        public async Task EnsureGetAllTicketsWorkProperly()
        {
            var service = new TicketService(this.DbContext);

            var ticket = new Ticket()
            {
                LuggageId = 1,
                PassengerId = 1,
                SeatNumber = "12",
                TicketRule = (TicketRule)Enum.Parse(typeof(TicketRule), "RoundTrip"),
                TicketType = (TicketType)Enum.Parse(typeof(TicketType), "Economy"),
                FlightId = 1,
            };

            var ticket2 = new Ticket()
            {
                LuggageId = 2,
                PassengerId = 2,
                SeatNumber = "13",
                TicketRule = (TicketRule)Enum.Parse(typeof(TicketRule), "RoundTrip"),
                TicketType = (TicketType)Enum.Parse(typeof(TicketType), "Economy"),
                FlightId = 1,
            };

            await this.DbContext.Tickets.AddAsync(ticket);
            await this.DbContext.Tickets.AddAsync(ticket2);
            await this.DbContext.SaveChangesAsync();

            var expectedCount = 2;
            var actual = service.GetAll().Count();

            Assert.Equal(expectedCount, actual);
        }

        [Fact]
        public void EnsureGetAllTicketsReturnZeroWhenNoTicketsInDb()
        {
            var service = new TicketService(this.DbContext);

            var expectedCount = 0;
            var actual = service.GetAll().Count();

            Assert.Equal(expectedCount, actual);
        }

        [Fact]
        public async Task EnsureGetAllTicketsByFlightIdWorkProperly()
        {
            var service = new TicketService(this.DbContext);

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

            var ticket = new Ticket()
            {
                LuggageId = 1,
                PassengerId = 1,
                SeatNumber = "12",
                TicketRule = (TicketRule)Enum.Parse(typeof(TicketRule), "RoundTrip"),
                TicketType = (TicketType)Enum.Parse(typeof(TicketType), "Economy"),
                FlightId = 1,
            };

            var ticket2 = new Ticket()
            {
                LuggageId = 2,
                PassengerId = 2,
                SeatNumber = "13",
                TicketRule = (TicketRule)Enum.Parse(typeof(TicketRule), "RoundTrip"),
                TicketType = (TicketType)Enum.Parse(typeof(TicketType), "Economy"),
                FlightId = 1,
            };

            await this.DbContext.Tickets.AddAsync(ticket);
            await this.DbContext.Tickets.AddAsync(ticket2);
            await this.DbContext.Flights.AddAsync(flight);
            await this.DbContext.SaveChangesAsync();

            var expectedCount = 2;
            var flightId = 1;
            var actual = service.GetAllByFlightId(flightId).Count();

            Assert.Equal(expectedCount, actual);
        }

        [Fact]
        public async Task EnsureGetAllTicketsByFlightIdReturnZeroWhenFlightDontHaveTickets()
        {
            var service = new TicketService(this.DbContext);

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

            await this.DbContext.Flights.AddAsync(flight);
            await this.DbContext.SaveChangesAsync();

            var expectedCount = 0;
            var flightId = 1;
            var actual = service.GetAllByFlightId(flightId).Count();

            Assert.Equal(expectedCount, actual);
        }

        [Fact]
        public async Task EnsureGetTicketByIdWorkProperly()
        {
            var service = new TicketService(this.DbContext);

            var ticket = new Ticket()
            {
                Id = 1,
                LuggageId = 1,
                PassengerId = 1,
                SeatNumber = "12",
                TicketRule = (TicketRule)Enum.Parse(typeof(TicketRule), "RoundTrip"),
                TicketType = (TicketType)Enum.Parse(typeof(TicketType), "Economy"),
                FlightId = 1,
            };

            var ticket2 = new Ticket()
            {
                Id = 2,
                LuggageId = 2,
                PassengerId = 2,
                SeatNumber = "13",
                TicketRule = (TicketRule)Enum.Parse(typeof(TicketRule), "RoundTrip"),
                TicketType = (TicketType)Enum.Parse(typeof(TicketType), "Economy"),
                FlightId = 1,
            };

            await this.DbContext.Tickets.AddAsync(ticket);
            await this.DbContext.Tickets.AddAsync(ticket2);
            await this.DbContext.SaveChangesAsync();

            var ticketId = 1;
            var actual = service.GetTicketById(ticketId);
            var expectedPassengerId = 1;
            var expectedSeatNumber = "12";
            var expectedFlightId = 1;

            Assert.NotNull(actual);
            Assert.Equal(expectedPassengerId, actual.PassengerId);
            Assert.Equal(expectedSeatNumber, actual.SeatNumber);
            Assert.Equal(expectedFlightId, actual.FlightId);
        }

        [Fact]
        public void EnsureGetTicketByIdReturnNullWhenNoMatch()
        {
            var service = new TicketService(this.DbContext);

            var ticketId = 1;
            var actual = service.GetTicketById(ticketId);

            Assert.Null(actual);
        }

        [Fact]
        public async Task EnsureGetTicketByPassengerIdWorkProperly()
        {
            var service = new TicketService(this.DbContext);

            var ticket = new Ticket()
            {
                Id = 0,
                LuggageId = 1,
                PassengerId = 1,
                SeatNumber = "12",
                TicketRule = (TicketRule)Enum.Parse(typeof(TicketRule), "RoundTrip"),
                TicketType = (TicketType)Enum.Parse(typeof(TicketType), "Economy"),
                FlightId = 1,
            };

            var ticket2 = new Ticket()
            {
                Id = 2,
                LuggageId = 1,
                PassengerId = 1,
                SeatNumber = "12",
                TicketRule = (TicketRule)Enum.Parse(typeof(TicketRule), "RoundTrip"),
                TicketType = (TicketType)Enum.Parse(typeof(TicketType), "Economy"),
                FlightId = 1,
            };
            await this.DbContext.Tickets.AddAsync(ticket);
            await this.DbContext.Tickets.AddAsync(ticket2);
            await this.DbContext.SaveChangesAsync();

            var passengerId = 1;
            var actual = service.GetTicketByPassengerId(passengerId);
            var expectedFlightId = 1;
            var expectedId = 0;

            Assert.NotNull(actual);
            Assert.Equal(expectedFlightId, actual.FlightId);
            Assert.Equal(expectedId, actual.Id);
        }

        [Fact]
        public void EnsureGetTicketByPassengerIdReturnNullWhenNoMatch()
        {
            var service = new TicketService(this.DbContext);

            var passengerId = 1;
            var actual = service.GetTicketByPassengerId(passengerId);

            Assert.Null(actual);
        }
    }
}
