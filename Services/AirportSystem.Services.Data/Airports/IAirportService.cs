namespace AirportSystem.Services.Data.Airport
{
    using System.Collections.Generic;

    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Services.Data.InputModels;

    public interface IAirportService
    {
        void CreateAirport(AirportInputModel airportInputModel);

        IEnumerable<Airport> GetAllAirports();

        Airport GetAirportById(string airportId);

       
    }
}
