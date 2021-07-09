namespace AirportSystem.Services.Data.Luggages
{
    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;
    using System.Collections.Generic;

    public interface ILuggageService
    {
        Luggage Create(LuggageInputModel luggageInputModel);

        void Edit(Luggage luggage, LuggageInputModel luggageInputModel);

        Luggage GetLuggageById(int luggageId);

        Luggage GetLuggageByPassengerId(int passengerId);

        IEnumerable<Luggage> GetLuggagesPassengerByPassId(int passengerId);

        decimal CalculatePrice(decimal price, LuggageType luggageType);
    }
}
