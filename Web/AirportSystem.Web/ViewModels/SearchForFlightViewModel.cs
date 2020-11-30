namespace AirportSystem.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SearchForFlightViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Origin { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Destination { get; set; }
    }
}
