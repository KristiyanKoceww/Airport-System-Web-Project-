namespace AirportSystem.Web.ViewModels
{
    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Mapping;

    public class AllAirportViewModel : IMapFrom<Airport>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public virtual City City { get; set; }
    }
}
