namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Destinations;

    public class CityService : ICityService
    {
        private readonly ApplicationDbContext db;

        public CityService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name)
        {
            var city = new City()
            {
                Name = name,
            };

            this.db.Cities.Add(city);
            this.db.SaveChanges();
        }

        public IEnumerable<City> GetAll()
        {
            var cities = this.db.Cities.Select(x => new City()
            {
                Name = x.Name,
                CountryId = x.CountryId,
                Id = x.Id,
            }).ToList();

            return cities;
        }
    }
}
