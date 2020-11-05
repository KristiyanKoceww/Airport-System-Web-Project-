namespace AirportSystem.Services.Data.CitiesAndCountries
{
    using System.Collections.Generic;

    using PlaneSystem.Data.Destinations;

    public interface ICityService
    {
        void Create(string name);

        IEnumerable<City> GetAll();
    }
}
