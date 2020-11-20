namespace AirportSystem.Services.Data.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CountryInputModel
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
