namespace AirportSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AirportSystem.Data;
    using AirportSystem.Services.Mapping;

    public class SearchLuggageViewModel : IMapFrom<Luggage>
    {
        [Required]
        [Display(Name = "Identifination number")]
        public int Id { get; set; }

        public LuggageType LuggageType { get; set; }

        [Required]
        public int PassengerId { get; set; }

        [Required]
        public string PassengerFirstName { get; set; }

        [Required]
        public decimal Weight { get; set; }
    }
}
