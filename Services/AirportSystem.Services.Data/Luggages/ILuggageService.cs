namespace AirportSystem.Services.Data.Luggages
{
    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;

    public interface ILuggageService
    {
        void Create(LuggageInputModel luggageInputModel);

        Luggage GetLuggageById(int luggageId);

        Luggage GetLuggageByPassengerId(int passengerId);

        decimal CalculatePrice(decimal price, LuggageType luggageType);
    }
}
