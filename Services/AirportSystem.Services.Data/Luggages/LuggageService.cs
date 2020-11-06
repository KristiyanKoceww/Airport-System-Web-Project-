﻿namespace AirportSystem.Services.Data.Luggages
{
    using System;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;
    using PlaneSystem.Data;

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
            };

            this.db.Luggage.Add(luggage);
            this.db.SaveChanges();
        }

        public Luggage GetLuggageById(string luggageId)
        {
            var luggage = this.db.Luggage.Where(x => x.Id == luggageId).FirstOrDefault();
            return luggage;
        }

        public Luggage GetLuggageByPassengerId(string passengerId)
        {
            var luggage = this.db.Luggage.Where(x => x.PassengerId == passengerId).FirstOrDefault();
            return luggage;
        }
    }
}
