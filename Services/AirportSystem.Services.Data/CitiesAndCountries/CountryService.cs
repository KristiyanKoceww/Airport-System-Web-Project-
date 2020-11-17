namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Data.InputModels;

    public class CountryService : ICountryService
    {
        private readonly ApplicationDbContext db;

        public CountryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(CountryInputModel countryInputModel)
        {
            var country = new Country()
            {
                Name = countryInputModel.Name,
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
