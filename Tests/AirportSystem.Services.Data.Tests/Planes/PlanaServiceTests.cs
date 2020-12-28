namespace AirportSystem.Services.Data.Tests.Planes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AirportSystem.Data.Models.Planes;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Planes;
    using Xunit;

    public class PlanaServiceTests : BaseServiceTests
    {
        [Fact]
        public void EnsureCreatePlaneIsWorkingCorrect()
        {
            var service = new PlaneService(this.DbContext);

            var planeModel = new PlaneInputModel()
            {
                Make = "Boeing",
                Model = "Jet 121",
                Type = "AirCraft",
                IsPlaneAvailable = true,
            };

            var planeModel2 = new PlaneInputModel()
            {
                Make = "Boeing2",
                Model = "Jet 1211",
                Type = "AirCraft",
                IsPlaneAvailable = true,
            };

            service.Create(planeModel);
            service.Create(planeModel2);

            var planes = this.DbContext.Planes.Count();
            var expected = 2;

            Assert.Equal(expected, planes);
        }

        [Fact]
        public async Task EnsureGetAllPlanesIsWorkingCorrect()
        {
            var service = new PlaneService(this.DbContext);
            var seats1 = new List<Seat>()
            {
                new Seat()
                {
                    
                    PlaneId = 1,
                    IsAvailable = true,
                },
                new Seat()
                {
                    
                    PlaneId = 1,
                    IsAvailable = true,
                },
            };
            var seats2 = new List<Seat>()
            {
                new Seat()
                {
                    
                    PlaneId = 1,
                    IsAvailable = true,
                },
                new Seat()
                {
                    
                    PlaneId = 1,
                    IsAvailable = true,
                },
            };
            var plane = new Plane()
            {
                Id = 1,
                Make = "Boeing",
                Model = "Jet 121",
                PlaneType = (PlaneType)Enum.Parse(typeof(PlaneType), "AirCraft"),
                IsPlaneAvailable = true,
                Seats = seats1,
            };

            var plane2 = new Plane()
            {
                Id = 2,
                Make = "Boeing",
                Model = "Jet 121",
                PlaneType = (PlaneType)Enum.Parse(typeof(PlaneType), "AirCraft"),
                IsPlaneAvailable = true,
                Seats = seats2,
            };

            await this.DbContext.Planes.AddAsync(plane);
            await this.DbContext.Planes.AddAsync(plane2);
            await this.DbContext.SaveChangesAsync();

            var planes = service.GetAllPlanes();
            var expected = 2;

            Assert.Equal(expected, planes.Count());
        }

        [Fact]
        public void EnsureGetAllPlanesReturnZeroWhenDbIsEmpty()
        {
            var service = new PlaneService(this.DbContext);

            var planes = service.GetAllPlanes();
            var expected = 0;

            Assert.Equal(expected, planes.Count());
        }

        [Fact]
        public async Task EnsureGetPlaneByIdIsWorkingProperly()
        {
            var service = new PlaneService(this.DbContext);
            var seats1 = new List<Seat>()
            {
                new Seat()
                {
                    
                    PlaneId = 1,
                    IsAvailable = true,
                },
                new Seat()
                {
                   
                    PlaneId = 1,
                    IsAvailable = true,
                },
            };

            var plane = new Plane()
            {
                Id = 1,
                Make = "Boeing",
                Model = "Jet 121",
                PlaneType = (PlaneType)Enum.Parse(typeof(PlaneType), "AirCraft"),
                IsPlaneAvailable = true,
                Seats = seats1,
            };
            await this.DbContext.Planes.AddAsync(plane);
            await this.DbContext.SaveChangesAsync();

            var id = 1;
            var expectedName = "Boeing";
            var expectedModel = "Jet 121";
            var planes = service.GetPlaneById(id);

            Assert.NotNull(planes);
            Assert.Equal(expectedName, planes.Make);
            Assert.Equal(expectedModel, planes.Model);
        }

        [Fact]
        public async Task EnsureGetPlaneByIdReturnNullWhenNoMatch()
        {
            var service = new PlaneService(this.DbContext);
            var seats1 = new List<Seat>()
            {
                new Seat()
                {
                   
                    PlaneId = 1,
                    IsAvailable = true,
                },
                new Seat()
                {
                   
                    PlaneId = 1,
                    IsAvailable = true,
                },
            };
            var seats2 = new List<Seat>()
            {
                new Seat()
                {
                   
                    PlaneId = 1,
                    IsAvailable = true,
                },
                new Seat()
                {
                   
                    PlaneId = 1,
                    IsAvailable = true,
                },
            };
            var plane = new Plane()
            {
                Id = 1,
                Make = "Boeing",
                Model = "Jet 121",
                PlaneType = (PlaneType)Enum.Parse(typeof(PlaneType), "AirCraft"),
                IsPlaneAvailable = true,
                Seats = seats1,
            };
            var plane2 = new Plane()
            {
                Id = 2,
                Make = "Boeing1",
                Model = "Jet 1212",
                PlaneType = (PlaneType)Enum.Parse(typeof(PlaneType), "AirCraft"),
                IsPlaneAvailable = true,
                Seats = seats2,
            };

            await this.DbContext.Planes.AddAsync(plane);
            await this.DbContext.Planes.AddAsync(plane2);
            await this.DbContext.SaveChangesAsync();

            var id = 3;
            var planes = service.GetPlaneById(id);

            Assert.Null(planes);
        }

        [Fact]
        public void EnsureGetPlaneByIdReturnNullWhenDbIsEmpty()
        {
            var service = new PlaneService(this.DbContext);

            var id = 1;
            var planes = service.GetPlaneById(id);

            Assert.Null(planes);
        }
    }
}
