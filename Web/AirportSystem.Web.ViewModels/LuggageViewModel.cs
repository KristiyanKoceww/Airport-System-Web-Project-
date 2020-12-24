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
        public LuggageType LuggageType { get; set; }

        [Required]
        public string PassengerId { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public string PassengerFirstName { get; set; }
    }
}
