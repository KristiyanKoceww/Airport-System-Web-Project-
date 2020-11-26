namespace AirportSystem.Services.Data.TravelLines
{
    using System.Collections.Generic;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;

    public interface ITravelLinesService
    {
        void CreateTravelLine(TravelLineInputModel travelLineInputModel);

        IEnumerable<TravelLine> GetAll();
    }
}
