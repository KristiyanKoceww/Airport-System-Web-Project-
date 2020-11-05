namespace AirportSystem.Services.Data.Airport
{
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Services.Data.InputModels;

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

        public Airport GetAirportById(string airportId)
        {
            var airport = this.db.Airports.Where(x => x.Id == airportId).FirstOrDefault();
            return airport;
        }

        public IEnumerable<Airport> GetAllAirports()
        {
            var airports = this.db.Airports.Select(x => new Airport
            {
                 Name = x.Name,
                 CityId = x.City.Id,
            }).ToList();

            return airports;
        }
    }
}
