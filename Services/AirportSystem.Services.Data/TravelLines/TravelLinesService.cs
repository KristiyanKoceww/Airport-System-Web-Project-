namespace AirportSystem.Services.Data.TravelLines
{
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;

    public class TravelLinesService : ITravelLinesService
    {
        private readonly ApplicationDbContext db;

        public TravelLinesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateTravelLine(TravelLineInputModel travelLineInputModel)
        {
            var travelLine = new TravelLine()
            {
                CityId = travelLineInputModel.CityId,
                City2Id = travelLineInputModel.City2Id,
                CityName = travelLineInputModel.CityName,
                CityName2 = travelLineInputModel.City2Name,
            };

            this.db.TravelLines.Add(travelLine);
            this.db.SaveChanges();
        }

        public TravelLine FindTravelLineByCityId(int cityId, int city2Id)
        {
            var travelLine = this.db.TravelLines.Where(x => x.CityId == cityId && x.City2Id == city2Id).FirstOrDefault();

            return travelLine;
        }

        public IEnumerable<TravelLine> GetAll()
        {
            var lines = this.db.TravelLines.Select(x => new TravelLine()
            {
                CityId = x.CityId,
                CityName = x.CityName,
                City2Id = x.City2Id,
                CityName2 = x.CityName2,
            }).ToList();

            return lines;
        }
    }
}
