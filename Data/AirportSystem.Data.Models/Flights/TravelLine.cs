namespace AirportSystem.Data
{
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Models.Destinations;

    public class TravelLine
    {
        [Required]
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }

        public virtual City City { get; set; }

        [Required]
        public int City2Id { get; set; }

        [Required]
        public string CityName2 { get; set; }

        public virtual City City2 { get; set; }
    }
}
