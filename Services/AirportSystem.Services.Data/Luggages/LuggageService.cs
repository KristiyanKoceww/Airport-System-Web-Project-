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

        public decimal CalculatePrice(decimal price, LuggageType luggageType)
        {
            switch (luggageType.ToString())
            {
                case "CarryOnBag":
                    return price;
                case "TrolleyBag":
                    price *= 1.15M;
                    break;
                case "CheckedInBag":
                    price *= 1.25M;
                    break;
            }

            return price;
        }

        public Luggage Create(LuggageInputModel luggageInputModel)
        {
            var luggage = new Luggage()
            {
                PassengerFirstName = luggageInputModel.PassengerFirstName,
                Weight = luggageInputModel.Weight,
                LuggageType = (LuggageType)Enum.Parse(typeof(LuggageType), luggageInputModel.LuggageType),
                PassengerId = luggageInputModel.PassengerId,
            };

            this.db.Luggage.Add(luggage);
            this.db.SaveChangesAsync();

            return luggage;
        }

        public void Edit(Luggage luggage, LuggageInputModel luggageInputModel)
        {
            var newLuggage = new Luggage()
            {
                PassengerFirstName = luggageInputModel.PassengerFirstName,
                Weight = luggageInputModel.Weight,
                LuggageType = (LuggageType)Enum.Parse(typeof(LuggageType), luggageInputModel.LuggageType),
                PassengerId = luggageInputModel.PassengerId,
            };

            luggage.IsDeleted = true;

            this.db.Luggage.AddAsync(newLuggage);
            this.db.SaveChangesAsync();
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
