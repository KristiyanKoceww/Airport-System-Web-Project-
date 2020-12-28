namespace AirportSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data;
    using AirportSystem.Services.Mapping;

    public class LuggageViewModel : IMapFrom<Luggage>
    {
        [Required]
        [Display(Name = "Please select luggage type")]
        public LuggageType LuggageType { get; set; }

        [Required]
        [Display(Name = "Your travel id")]
        public string PassengerId { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "luggage weight")]
        public decimal Weight { get; set; }

        [Required]
        [Display(Name = "Your first name")]
        public string PassengerFirstName { get; set; }
    }
}
