namespace AirportSystem.Services.Data.InputModels
{
    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Services.Mapping;

    public class AirportInputModel : IMapFrom<Airport>
    {
        public string Name { get; set; }

        public string CityId { get; set; }
    }
}
