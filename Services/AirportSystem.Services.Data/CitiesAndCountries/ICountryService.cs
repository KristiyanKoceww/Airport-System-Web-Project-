namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;

    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Data.InputModels;

    public interface ICountryService
    {
        void Create(CountryInputModel countryInputModel );

        IEnumerable<Country> GetAll();
    }
}
