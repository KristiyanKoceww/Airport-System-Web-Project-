namespace AirportSystem.Services.Data.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Models.Planes;

    public class PlaneInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Name must contains only letters")]
        public string Make { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Name must contains only letters")]
        public string Model { get; set; }

        [Required]
        [Range(20, 100)]
        public int SeatsCount { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public bool IsPlaneAvailable { get; set; }
    }
}
