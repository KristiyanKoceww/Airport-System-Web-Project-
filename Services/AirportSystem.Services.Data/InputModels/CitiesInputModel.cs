namespace AirportSystem.Services.Data.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CitiesInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Name must contains only letters")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CountryId contains only digits!")]
        public int CountryId { get; set; }
    }
}
