namespace AirportSystem.Services.Data.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class ExtendCityInputModel
    {
        [Required]
        public IEnumerable<IFormFile> Images { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        public string OriginalUrl { get; set; }
    }
}
