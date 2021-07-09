namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data;
    using AirportSystem.Data.Models;
    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

    public class CityService : ICityService
    {
        private readonly ApplicationDbContext db;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };

        public CityService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddImageAndDescriptionToCity(ExtendCityInputModel extendCityInputModel, string imagePath)
        {
            var city = this.FindCityByName(extendCityInputModel.CityName);

            city.Description = extendCityInputModel.Description;
            city.OriginalUrl = extendCityInputModel.OriginalUrl;

            Directory.CreateDirectory($"{imagePath}/cities/");
            foreach (var image in extendCityInputModel.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    City = city,
                    CityId = city.Id.ToString(),
                    Extension = extension,
                };

                city.Images.Add(dbImage);
                this.db.Cities.Update(city);
                await this.db.Images.AddAsync(dbImage);

                var physicalPath = $"{imagePath}/cities/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.db.SaveChangesAsync();
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

        public City FindCityById(int cityId)
        {
            var city = this.db.Cities.Find(cityId);

            return city;
        }

        public City FindCityByName(string cityName)
        {
            var city = this.db.Cities.FirstOrDefault(x => x.Name == cityName);
            return city;
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

        public IEnumerable<City> GetAllCities()
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
