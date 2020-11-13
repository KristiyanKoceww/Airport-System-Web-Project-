namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;

    using AirportSystem.Data.Destinations;

    public interface ICityService
    {
        void Create(string name);

        IEnumerable<City> GetAll();
    }
}
