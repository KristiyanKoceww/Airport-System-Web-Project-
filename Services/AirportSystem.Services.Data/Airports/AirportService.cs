namespace AirportSystem.Services.Data.Airport
{
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

    public class AirportService : IAirportService
    {
        private readonly ApplicationDbContext db;

        public AirportService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateAirport(AirportInputModel airportInputModel)
        {
            var airport = new Airport()
            {
                Name = airportInputModel.Name,
                CityId = airportInputModel.CityId,
            };

            this.db.Airports.Add(airport);
            this.db.SaveChanges();
        }

        public Airport GetAirportById(int airportId)
        {
            var airport = this.db.Airports.Where(x => x.Id == airportId).FirstOrDefault();
            return airport;
        }

        public IEnumerable<Airport> GetAirportNameAndId()
        {
            var airports = this.db.Airports.Select(x => new Airport
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return airports;
        }

        public IEnumerable<AllAirportViewModel> GetAllAirports()
        {
            var airports = this.db.Airports.Select(x => new AllAirportViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CityId = x.City.Id,
                CityName = x.City.Name,
            }).ToList();

            return airports;
        }
    }
}
