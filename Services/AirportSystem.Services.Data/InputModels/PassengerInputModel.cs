namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data;
    using AirportSystem.Data.Passengers;

    public class PassengerInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Name must contains only letters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Name must contains only letters")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Name must contains only letters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Range(18, 99)]
        public int Age { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        public string Address { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [Display(Name = "Passport identification number")]
        public string PassportId { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
    }
}
