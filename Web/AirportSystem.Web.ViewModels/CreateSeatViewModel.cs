namespace AirportSystem.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateSeatViewModel
    {
        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        [Range(20, 100)]
        public int SeatsCount { get; set; }

        [Required]
        public int PlaneId { get; set; }
    }
}
