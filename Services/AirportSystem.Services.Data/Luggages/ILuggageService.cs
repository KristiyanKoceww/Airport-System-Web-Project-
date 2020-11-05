namespace AirportSystem.Services.Data.Luggages
{
    using AirportSystem.Services.Data.InputModels;
    using PlaneSystem.Data;

    public interface ILuggageService
    {
        void Create(LuggageInputModel luggageInputModel);

        Luggage GetLuggageById(string luggageId);

        Luggage GetLuggageByPassengerId(string passengerId);
    }
}
