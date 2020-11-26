namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Mapping;

    public class AirportInputModel : IMapFrom<Airport>
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int CityId { get; set; }
       
    }
}
