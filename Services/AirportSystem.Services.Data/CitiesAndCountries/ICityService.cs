namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;

    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

    public interface ICityService
    {
        void Create(CitiesInputModel citiesInputModel);

        IEnumerable<AllCityViewModel> GetAll();

        IEnumerable<City> GetAllCities();

        City FindCityById(int CityId);
    }
}
