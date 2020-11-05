namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;

    using PlaneSystem.Data.Destinations;

    public interface ICountryService
    {
        void Create(string name);

        IEnumerable<Country> GetAll();
    }
}
