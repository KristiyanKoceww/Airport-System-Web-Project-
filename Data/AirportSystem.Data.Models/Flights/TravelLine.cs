namespace AirportSystem.Data
{
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Destinations;

    public class TravelLine
    {
        [Required]
        public string CityId { get; set; }

        [Required]
        public string City2Id { get; set; }

        public City City { get; set; }
    }
}
