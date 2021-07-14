namespace AirportSystem.Services.Data.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class CitiesInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Name must contains only letters")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CountryId contains only digits!")]
        [Display(Name = "Country Id")]
        public int CountryId { get; set; }

        [Required]
        public IEnumerable<IFormFile> Images { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(100)]
        public string Description { get; set; }

        public string OriginalUrl { get; set; }
    }
}
