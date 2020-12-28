namespace AirportSystem.Services.Data.Tests.Cities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Mapping;
    using AirportSystem.Web.Controllers;
    using AirportSystem.Web.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CitiesServiceTests : BaseServiceTests
    {
        [Fact]
        public void ShouldReturnCitiesCorrectlyWhenEmptyDb()
        {
            var service = new CityService(this.DbContext);

            var allCities = service.GetAll();

            var expecedCitiesCount = 0;
            var actualCitiesCount = allCities.Count();

            Assert.Equal(expecedCitiesCount, actualCitiesCount);
        }

        [Fact]
        public async Task ShouldReturnCityByIdCorrectly()
        {
            var service = new CityService(this.DbContext);

            var newCity = new City()
            {
                CountryId = 1,
                Id = 1,
                Name = "Sofia",
            };

            await this.DbContext.Cities.AddAsync(newCity);
            await this.DbContext.SaveChangesAsync();

            var city = service.FindCityById(newCity.Id);

            var expecedCitiesCount = 1;
            var actualCitiesCount = city.Id;

            Assert.Equal(expecedCitiesCount, actualCitiesCount);
        }

        [Fact]
        public void ShouldReturnNullGetByIdWhenIdIsNull()
        {
            var service = new CityService(this.DbContext);

            int cityId = 11111111;

            var city = service.FindCityById(cityId);

            Assert.Null(city);
        }

        [Fact]
        public void CreateShouldWorkCorrectly()
        {
            var service = new CityService(this.DbContext);

            var model = new CitiesInputModel()
            {
                Name = "sofia",
                CountryId = 1,
            };
            var model2 = new CitiesInputModel()
            {
                Name = "sofia2",
                CountryId = 1,
            };

            service.Create(model);
            service.Create(model2);

            var expecedCitiesCount = 2;
            var actualCitiesCount = service.GetAllCities().Count();

            Assert.Equal(expecedCitiesCount, actualCitiesCount);
        }

        [Fact]
        public void GetAllCitiesShouldReturnCitiesCorrectlyWhenEmptyDb()
        {
            var service = new CityService(this.DbContext);

            var allCities = service.GetAllCities();

            var expecedCitiesCount = 0;
            var actualCitiesCount = allCities.Count();

            Assert.Equal(expecedCitiesCount, actualCitiesCount);
        }
    }
}
