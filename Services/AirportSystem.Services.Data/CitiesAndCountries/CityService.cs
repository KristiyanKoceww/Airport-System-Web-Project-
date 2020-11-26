namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

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

        public IEnumerable<AllCityViewModel> GetAll()
        {
            var cities = this.db.Cities.Select(x => new AllCityViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CountryId = x.CountryId,
                CountryName = x.Country.Name,
            }).ToList();

            return cities;
        }
    }
}
