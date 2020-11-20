namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class LuggageInputModel
    {
        [Required]
        public int PassengerId { get; set; }

        [Required]
        public string LuggageType { get; set; }

        [Required]
        public decimal Weight { get; set; }
    }
}
