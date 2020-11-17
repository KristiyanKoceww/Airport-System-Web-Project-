namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class LuggageInputModel
    {
        [Required]
        [MaxLength(30)]
        public string LuggageType { get; set; }

        [Required]
        [MaxLength(30)]
        public decimal Weight { get; set; }
    }
}
