namespace AirportSystem.Services.Data.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Common.CustomAttribues;

    public class PassportInputModel
    {
        [Required]
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
    }
}
