namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Data.InputModels;

    public class CityService : ICityService
    {
        private readonly ApplicationDbContext db;

        public CityService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(CitiesInputModel citiesInputModel)
        {
            var city = new City()
            {
                Name = citiesInputModel.Name,
                CountryId = citiesInputModel.CountryId,
            };

            this.db.Cities.Add(city);
            this.db.SaveChanges();
        }

        public IEnumerable<City> GetAll()
        {
            var cities = this.db.Cities.Select(x => new City()
            {
                Id = x.Id,
                Name = x.Name,
                CountryId = x.CountryId,
            }).ToList();

            return cities;
        }
    }
}
