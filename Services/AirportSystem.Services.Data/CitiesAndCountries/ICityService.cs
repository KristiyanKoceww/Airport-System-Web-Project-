namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AirportSystem.Data.Models;
    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

    public interface ICityService
    {
        void Create(CitiesInputModel citiesInputModel);

        IEnumerable<AllCityViewModel> GetAll();

        IEnumerable<City> GetAllCities();

        Task AddImageAndDescriptionToCity(ExtendCityInputModel extendCityInputModel,string imagePath);

        City FindCityById(int cityId);

        City FindCityByName(string cityName);
    }
}
