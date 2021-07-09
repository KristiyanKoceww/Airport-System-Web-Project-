namespace AirportSystem.Services.Data.Luggages
{
    using System;
    using System.Collections.Generic;
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
            CheckLuggageWeight(luggageInputModel);

            var luggage = new Luggage()
            {
                PassengerFirstName = luggageInputModel.PassengerFirstName,
                Weight = luggageInputModel.Weight,
                LuggageType = (LuggageType)Enum.Parse(typeof(LuggageType), luggageInputModel.LuggageType),
                PassengerId = luggageInputModel.PassengerId,
            };
            var passenger = this.db.Passengers.Where(x => x.Id == luggageInputModel.PassengerId).FirstOrDefault();

            if (passenger != null)
            {
                passenger.Luggage.Add(luggage);
            }

            this.db.Luggage.Add(luggage);
            this.db.SaveChanges();

            return luggage;
        }

        public void Edit(Luggage luggage, LuggageInputModel luggageInputModel)
        {
            CheckLuggageWeight(luggageInputModel);

            var newLuggage = new Luggage()
            {
                PassengerFirstName = luggageInputModel.PassengerFirstName,
                Weight = luggageInputModel.Weight,
                LuggageType = (LuggageType)Enum.Parse(typeof(LuggageType), luggageInputModel.LuggageType),
                PassengerId = luggageInputModel.PassengerId,
            };

            luggage.IsDeleted = true;

            var passenger = this.db.Passengers.Where(x => x.Id == luggageInputModel.PassengerId).FirstOrDefault();
            passenger.Luggage.Add(newLuggage);
            this.db.Luggage.Add(newLuggage);
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

        public IEnumerable<Luggage> GetLuggagesPassengerByPassId(int passengerId)
        {
            var luggage = this.db.Luggage.Where(x => x.PassengerId == passengerId).ToList();
            return luggage;
        }

        private static void CheckLuggageWeight(LuggageInputModel luggageInputModel)
        {

            if (luggageInputModel.Weight > 0 && luggageInputModel.Weight <= 10)
            {
                luggageInputModel.LuggageType = "1";
            }
            else if (luggageInputModel.Weight > 10 && luggageInputModel.Weight <= 20)
            {
                luggageInputModel.LuggageType = "2";
            }
            else if (luggageInputModel.Weight > 20 && luggageInputModel.Weight <= 100)
            {
                luggageInputModel.LuggageType = "3";
            }
        }
    }
}
