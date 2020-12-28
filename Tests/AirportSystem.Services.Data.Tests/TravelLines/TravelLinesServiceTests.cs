namespace AirportSystem.Services.Data.Tests.TravelLines
{
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.TravelLines;
    using Xunit;

    public class TravelLinesServiceTests : BaseServiceTests
    {
        [Fact]
        public void EnsureCreateTravelLineWorkProperly()
        {
            var service = new TravelLinesService(this.DbContext);

            var model = new TravelLineInputModel()
            {
                CityId = 1,
                CityName = "Sofia",
                City2Id = 2,
                City2Name = "Varna",
            };

            var model2 = new TravelLineInputModel()
            {
                CityId = 3,
                CityName = "Plovid",
                City2Id = 4,
                City2Name = "Burgas",
            };

            service.CreateTravelLine(model);
            service.CreateTravelLine(model2);

            var expectedCount = 2;
            var actual = this.DbContext.TravelLines.Count();

            Assert.Equal(expectedCount, actual);
        }

        [Fact]
        public async Task EnsureFindTravelLineByCityIdWorkProperly()
        {
            var service = new TravelLinesService(this.DbContext);

            var model = new TravelLine()
            {
                CityId = 1,
                CityName = "Sofia",
                City2Id = 2,
                CityName2 = "Varna",
            };

            await this.DbContext.TravelLines.AddAsync(model);
            await this.DbContext.SaveChangesAsync();

            var cityId = 1;
            var cityId2 = 2;

            var travelLine = service.FindTravelLineByCityId(cityId, cityId2);
            var expectedName = "Sofia";
            var expectedName2 = "Varna";
            Assert.NotNull(travelLine);
            Assert.Equal(expectedName, travelLine.CityName);
            Assert.Equal(expectedName2, travelLine.CityName2);
        }

        [Fact]
        public void EnsureFindTravelLineByCityIdReturnNullWhenNoMatch()
        {
            var service = new TravelLinesService(this.DbContext);

            var cityId = 1;
            var cityId2 = 2;

            var travelLine = service.FindTravelLineByCityId(cityId, cityId2);

            Assert.Null(travelLine);
        }

        [Fact]
        public async Task EnsureGetAllWorkProperly()
        {
            var service = new TravelLinesService(this.DbContext);

            var model = new TravelLine()
            {
                CityId = 1,
                CityName = "Sofia",
                City2Id = 2,
                CityName2 = "Varna",
            };
            var model2 = new TravelLine()
            {
                CityId = 3,
                CityName = "Plovid",
                City2Id = 4,
                CityName2 = "Burgas",
            };
            var model3 = new TravelLine()
            {
                CityId = 5,
                CityName = "Ruse",
                City2Id = 6,
                CityName2 = "Petrich",
            };

            await this.DbContext.TravelLines.AddAsync(model);
            await this.DbContext.TravelLines.AddAsync(model2);
            await this.DbContext.TravelLines.AddAsync(model3);
            await this.DbContext.SaveChangesAsync();

            var travellines = service.GetAll();
            var actual = travellines.Count();
            var expectedCount = 3;

            Assert.NotEmpty(travellines);
            Assert.Equal(expectedCount, actual);
        }

        [Fact]
        public void EnsureGetAllReturnZeroWhenNoRecordInDb()
        {
            var service = new TravelLinesService(this.DbContext);

            var travellines = service.GetAll();
            var actual = travellines.Count();
            var expectedCount = 0;

            Assert.Empty(travellines);
            Assert.Equal(expectedCount, actual);
        }
    }
}
