namespace AirportSystem.Services.Data.Luggages
{
    using System;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;

    public class LuggageService : ILuggageService
    {
        private readonly ApplicationDbContext db;

        public LuggageService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(LuggageInputModel luggageInputModel)
        {
            var luggage = new Luggage()
            {
                Weight = luggageInputModel.Weight,
                LuggageType = (LuggageType)Enum.Parse(typeof(LuggageType), luggageInputModel.LuggageType),
                PassengerId = luggageInputModel.PassengerId,
            };

            this.db.Luggage.Add(luggage);
            this.db.SaveChanges();
        }

        public Luggage GetLuggageById(int luggageId)
        {
            var luggage = this.db.Luggage.Where(x => x.Id == luggageId).FirstOrDefault();
            return luggage;
        }

        public Luggage GetLuggageByPassengerId(int passengerId)
        {
            var luggage = this.db.Luggage.Where(x => x.PassengerId == passengerId).FirstOrDefault();
            return luggage;
        }
    }
}
