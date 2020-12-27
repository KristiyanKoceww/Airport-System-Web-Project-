namespace AirportSystem.Services.Data.Tests.Airports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Services.Data.Airport;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;
    using Xunit;

    public class AirportServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task EnsureCreateAirportWorkProperly()
        {
            var service = new AirportService(this.DbContext);

            var model = new AirportInputModel()
            {
                CityId = 1,
                Name = "BerlinAirport",
            };

            service.CreateAirport(model);

            var expectedCount = 1;
            var result = this.DbContext.Airports.Count();
            var airport = this.DbContext.Airports.FirstOrDefault();

            Assert.Equal(expectedCount, result);
            Assert.Equal("BerlinAirport", airport.Name);
        }

        [Fact]
        public async Task EnsureGetAirportByIdWorkProperly()
        {
            var service = new AirportService(this.DbContext);

            var airport = new Airport()
            {
                Id = 1,
                Name = "GermanyAirport",
                CityId = 1,
            };
            var airport2 = new Airport()
            {
                Id = 2,
                Name = "FranceAirport",
                CityId = 2,
            };

            await this.DbContext.Airports.AddAsync(airport);
            await this.DbContext.Airports.AddAsync(airport2);
            await this.DbContext.SaveChangesAsync();

            var expectedId = 1;
            var expectedId2 = 2;

            var result = service.GetAirportById(1);
            var result2 = service.GetAirportById(2);

            Assert.Equal(expectedId, result.Id);
            Assert.Equal(expectedId2, result2.Id);
        }

        [Fact]
        public async Task EnsureGetAirportByIdReturnNullWhenNoMatch()
        {
            var service = new AirportService(this.DbContext);

            var airport = new Airport()
            {
                Id = 1,
                Name = "GermanyAirport",
                CityId = 1,
            };
            var airport2 = new Airport()
            {
                Id = 2,
                Name = "FranceAirport",
                CityId = 2,
            };

            await this.DbContext.Airports.AddAsync(airport);
            await this.DbContext.Airports.AddAsync(airport2);
            await this.DbContext.SaveChangesAsync();

            var result = service.GetAirportById(3);
            var result2 = service.GetAirportById(4);

            Assert.Null(result);
            Assert.Null(result2);
        }

        [Fact]
        public async Task EnsureGetAirportByIdReturnNullDbIsEmpty()
        {
            var service = new AirportService(this.DbContext);

            var result = service.GetAirportById(3);
            var result2 = service.GetAirportById(4);

            Assert.Null(result);
            Assert.Null(result2);
        }

        [Fact]
        public async Task EnsureGetAirportNameAndIdWorkProperly()
        {
            var service = new AirportService(this.DbContext);

            var airport = new Airport()
            {
                Id = 1,
                Name = "GermanyAirport",
                CityId = 1,
            };

            await this.DbContext.Airports.AddAsync(airport);
            await this.DbContext.SaveChangesAsync();

            var result = service.GetAirportNameAndId();
            var airport2 = result.FirstOrDefault();

            Assert.Equal(1, airport2.Id);
            Assert.Equal("GermanyAirport", airport2.Name);
        }

        [Fact]
        public async Task EnsureGetAirportNameAndIdReturnNullWhenEmptyDb()
        {
            var service = new AirportService(this.DbContext);

            var result = service.GetAirportNameAndId();

            Assert.Empty(result);
        }

        [Fact]
        public async Task EnsureGetAllAirportsWorkProperly()
        {
            var service = new AirportService(this.DbContext);

            var airport = new AllAirportViewModel()
            {
                Id = 1,
                Name = "GermanyAirport",
                CityId = 1,
                CityName = "Berlin",
            };

            
           
            await this.DbContext.SaveChangesAsync();

            var result = service.GetAllAirports();

            Assert.Equal(2, result.Count());
        }

    }
}
