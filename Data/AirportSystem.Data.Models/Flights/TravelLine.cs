namespace AirportSystem.Data
{
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Models.Destinations;

    public class TravelLine
    {
        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        [Required]
        public int City2Id { get; set; }

        public virtual City City2 { get; set; }

    }
}
