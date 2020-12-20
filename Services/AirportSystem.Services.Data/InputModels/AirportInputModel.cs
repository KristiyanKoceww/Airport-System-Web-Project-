namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Mapping;

    public class AirportInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CityId contains only digits!")]
        public int CityId { get; set; }
    }
}
