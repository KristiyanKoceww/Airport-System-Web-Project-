namespace AirportSystem.Common.CustomAttribues
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PassportDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            value = (DateTime)value;
            // This assumes inclusivity, i.e. exactly six years ago is okay
            if (DateTime.Now.AddYears(-10).CompareTo(value) <= 0 && DateTime.Now.AddYears(10).CompareTo(value) >= 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Passports details are invalid.");
            }
        }
    }
}
