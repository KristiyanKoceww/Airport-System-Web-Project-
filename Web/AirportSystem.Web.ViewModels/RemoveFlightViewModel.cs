namespace AirportSystem.Web.ViewModels
{
    using AirportSystem.Data;
    using AirportSystem.Services.Mapping;

    public class RemoveFlightViewModel : IMapFrom<Flight>
    {
        public int Id { get; set; }
    }
}
