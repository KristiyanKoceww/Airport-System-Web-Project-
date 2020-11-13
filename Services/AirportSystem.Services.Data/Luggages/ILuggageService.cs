﻿namespace AirportSystem.Services.Data.Luggages
{
    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;

    public interface ILuggageService
    {
        void Create(LuggageInputModel luggageInputModel);

        Luggage GetLuggageById(string luggageId);

        Luggage GetLuggageByPassengerId(string passengerId);
    }
}