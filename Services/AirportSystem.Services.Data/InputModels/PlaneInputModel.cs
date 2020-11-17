namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class PlaneInputModel
    {
        [Required]
        [MaxLength(30)]
        public string Make { get; set; }

        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public bool IsPlaneAvailable { get; set; }
    }
}
