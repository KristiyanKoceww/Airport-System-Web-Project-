using AirportSystem.Data.Models.Destinations;
using AirportSystem.Services.Data.CitiesAndCountries;
using AirportSystem.Services.Data.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirportSystem.Services.Data.Tests.Countries
{
    public class CountriesServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task EnsureCreateWorkingProperly()
        {

            var service = new CountryService(this.DbContext);

            var model = new CountryInputModel()
            {
                Name = "Germany",
            };

            service.Create(model);

            var countries = this.DbContext.Countries.Count();
            var country = this.DbContext.Countries.FirstOrDefault();
            var expected = 1;

            Assert.Equal(expected, countries);
            Assert.Equal("Germany", country.Name);
        }

        [Fact]
        public async Task EnsureFindCountryByIdWorkProperly()
        {

            var service = new CountryService(this.DbContext);

            var country = new Country()
            {
                Id = 1,
                Name = "Germany",
            };

            await this.DbContext.Countries.AddAsync(country);
            await this.DbContext.SaveChangesAsync();

            var countrY = service.FindCountryById(1);

            var expected = 1;
            var result = countrY.Id;

            Assert.Equal(expected, result);

        }

        [Fact]
        public async Task EnsureFindCountryByIdReturnNullWhenNoMatch()
        {
            var service = new CountryService(this.DbContext);
            var countrY = service.FindCountryById(1);

            Assert.Null(countrY);

        }

        [Fact]
        public async Task EnsureGetAllWorkProperly()
        {
            var service = new CountryService(this.DbContext);

            var country = new Country()
            {
                Id = 1,
                Name = "Germany",
            };
            var country2 = new Country()
            {
                Id = 2,
                Name = "France",
            };

            await this.DbContext.Countries.AddAsync(country);
            await this.DbContext.Countries.AddAsync(country2);
            await this.DbContext.SaveChangesAsync();

            var expected = 2;
            var result = service.GetAll().Count();

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task EnsureGetAllRetunZeroWhenDbIsEmpty()
        {
            var service = new CountryService(this.DbContext);
            var expected = 0;
            var result = service.GetAll().Count();

            Assert.Equal(expected, result);
        }
    }
}
