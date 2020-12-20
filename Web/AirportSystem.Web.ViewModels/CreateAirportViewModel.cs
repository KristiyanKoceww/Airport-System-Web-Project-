namespace AirportSystem.Web.ViewModels
{
    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Services.Mapping;

    public class CreateAirportViewModel : IMapFrom<Airport>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CityId { get; set; }
    }
}
