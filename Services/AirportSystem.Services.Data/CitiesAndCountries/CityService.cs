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
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    public class CityService : ICityService
    {
        private readonly ApplicationDbContext db;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };

        public CityService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(CitiesInputModel citiesInputModel, string imagePath)
        {
            var city = new City()
            {
                Name = citiesInputModel.Name,
                CountryId = citiesInputModel.CountryId,
                OriginalUrl = citiesInputModel.OriginalUrl,
                Description = citiesInputModel.Description,
            };

            foreach (var image in citiesInputModel.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    City = city,
                    CityId = city.Id,
                    Extension = extension,
                    RemoteImageUrl = citiesInputModel.ImageUrl,
                };

                city.Images.Add(dbImage);
                this.db.Images.Add(dbImage);

                //var physicalPath = $"{imagePath}/cities/{dbImage.Id}.{extension}";

                Account account = new Account(
             Common.GlobalConstants.CloundName,
             Common.GlobalConstants.CloudApiKey,
             Common.GlobalConstants.CloudApiSecret);

                Cloudinary cloudinary = new Cloudinary(account);
                cloudinary.Api.Secure = true;

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription($"{citiesInputModel.ImageUrl}"),
                };

                var uploadResult = cloudinary.Upload(uploadParams);
            }

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

        public IEnumerable<City> GetRandomCities()
        {
            var cities = this.db.Cities.Where(x => x.Images.Count > 0).Select(x => new City()
            {
                Id = x.Id,
                Country = x.Country,
                CountryId = x.CountryId,
                Description = x.Description,
                Name = x.Name,
                OriginalUrl = x.OriginalUrl,
                Images = x.Images,
            }).Take(6).ToList();

            return cities;
        }
    }
}
