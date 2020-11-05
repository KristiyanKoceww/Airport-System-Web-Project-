namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using PlaneSystem.Data.Destinations;

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
            var cities = this.db.Countries.Select(x => new City()
            {
                Name = x.Name,
            }).ToList();

            return cities;
        }
    }
}
