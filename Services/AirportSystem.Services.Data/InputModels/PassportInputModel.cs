namespace AirportSystem.Services.Data.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Common.CustomAttribues;

    public class PassportInputModel
    {
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Passport Id contains only digits!")]
        [Display(Name = "Passport identification number")]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Passport valid from :")]
        [PassportDateValidationAttribute]
        public DateTime CreatedOn { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Passport expiry date:")]
        [PassportDateValidationAttribute]
        public DateTime ExpiresOn { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Country must contains only letters")]
        public string Country { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Nationality must contains only letters")]
        public string Nationality { get; set; }
    }
}
