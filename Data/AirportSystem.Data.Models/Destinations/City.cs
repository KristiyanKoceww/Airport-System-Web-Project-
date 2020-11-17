namespace AirportSystem.Data.Models.Destinations
{
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {

        }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
