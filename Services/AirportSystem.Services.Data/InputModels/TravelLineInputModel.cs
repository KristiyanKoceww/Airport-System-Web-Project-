namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class TravelLineInputModel
    {
        [Required]
        public int CityId { get; set; }

        [Required]
        public int City2Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string CityName { get; set; }

        [Required]
        [MaxLength(40)]
        public string City2Name { get; set; }
    }
}
