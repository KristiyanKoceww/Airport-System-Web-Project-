namespace AirportSystem.Services.Data.Tests.Seats
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data.Models.Planes;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Data.Seats;

    using Xunit;

    public class SeatsServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task EnsureCreateSeatsWorkProperly()
        {
            var service = new SeatsService(this.DbContext);

            var plane = new Plane()
            {
                Id = 1,
                Make = "Boeing",
                Model = "Jet 121",
                PlaneType = (PlaneType)Enum.Parse(typeof(PlaneType), "AirCraft"),
                IsPlaneAvailable = true,
            };

            await this.DbContext.Planes.AddAsync(plane);
            await this.DbContext.SaveChangesAsync();

            var count = 5;
            var isAvailable = true;
            var planeId = 1;

            service.Create(isAvailable, count, planeId);
            var planeInDb = this.DbContext.Planes.Find(planeId);
            var expectedCount = 5;
            var seat = planeInDb.Seats.FirstOrDefault();
            var expectedSeatValue = true;

            Assert.Equal(expectedCount, planeInDb.Seats.Count());
            Assert.Equal(expectedSeatValue, seat.IsAvailable);
        }

        [Fact]
        public async Task EnsureGetSeatsByPlaneIdWorkProperly()
        {
            var service = new SeatsService(this.DbContext);

            var plane = new Plane()
            {
                Id = 1,
                Make = "Boeing",
                Model = "Jet 121",
                PlaneType = (PlaneType)Enum.Parse(typeof(PlaneType), "AirCraft"),
                IsPlaneAvailable = true,
            };

            var seat = new Seat()
            {
                SeatNumber = 1,
                PlaneId = 1,
                IsAvailable = true,
            };

            var seat2 = new Seat()
            {
                SeatNumber = 2,
                PlaneId = 1,
                IsAvailable = true,
            };

            plane.Seats.Add(seat);
            plane.Seats.Add(seat2);

            await this.DbContext.Planes.AddAsync(plane);
            await this.DbContext.SaveChangesAsync();

            var planeId = 1;
            var seats = service.GetSeatsByPlaneId(planeId);

            var expectedCount = 2;
            var expectedSeatValue = true;
            var planeInDb = this.DbContext.Planes.Where(x => x.Id == planeId).FirstOrDefault();
            var planeSeat = planeInDb.Seats.FirstOrDefault();

            Assert.Equal(expectedCount, seats.Count());
            Assert.Equal(expectedSeatValue, planeSeat.IsAvailable);
        }

        [Fact]
        public async Task EnsureGetSeatsByPlaneReturnZeroWhenNoSeats()
        {
            var service = new SeatsService(this.DbContext);

            var plane = new Plane()
            {
                Id = 1,
                Make = "Boeing",
                Model = "Jet 121",
                PlaneType = (PlaneType)Enum.Parse(typeof(PlaneType), "AirCraft"),
                IsPlaneAvailable = true,
            };

            await this.DbContext.Planes.AddAsync(plane);
            await this.DbContext.SaveChangesAsync();

            var planeId = 1;
            var seats = service.GetSeatsByPlaneId(planeId);

            var expectedCount = 0;

            Assert.Equal(expectedCount, seats.Count());
        }
    }
}
