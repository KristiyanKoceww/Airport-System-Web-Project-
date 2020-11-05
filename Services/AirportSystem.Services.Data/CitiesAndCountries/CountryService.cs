namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;
    using System.Linq;
    using AirportSystem.Data;
    using PlaneSystem.Data.Destinations;

    public class CountryService : ICountryService
    {
        private readonly ApplicationDbContext db;

        public CountryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name)
        {
            var country = new Country()
            {
                Name = name,
            };

            this.db.Countries.Add(country);
            this.db.SaveChanges();
        }

        public IEnumerable<Country> GetAll()
        {
            var coutries = this.db.Countries.Select(x => new Country()
            {
                Name = x.Name,
            }).ToList();

            return coutries;
        }
    }
}
