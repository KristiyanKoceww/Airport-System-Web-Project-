namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class LuggageInputModel
    {
        [Required]
        [Display(Name = "First name")]
        public string PassengerFirstName { get; set; }

        [Required]
        [Display(Name = "Your travel id")]
        public int PassengerId { get; set; }

        [Required]
        [Display(Name = "Choose your luggage type")]
        public string LuggageType { get; set; }

        [Required]
        [Range(5, 100)]
        public decimal Weight { get; set; }
    }
}
