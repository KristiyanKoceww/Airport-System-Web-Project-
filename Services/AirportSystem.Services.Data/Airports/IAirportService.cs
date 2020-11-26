namespace AirportSystem.Services.Data.Airport
{
    using System.Collections.Generic;

    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

    public interface IAirportService
    {
        void CreateAirport(AirportInputModel airportInputModel);

        IEnumerable<AllAirportViewModel> GetAllAirports();

        IEnumerable<Airport> GetAirportNameAndId();

        Airport GetAirportById(int airportId);
    }
}
