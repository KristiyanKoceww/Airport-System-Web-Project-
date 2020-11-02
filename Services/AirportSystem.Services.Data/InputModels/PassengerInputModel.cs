namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class PassengerInputModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PassportId { get; set; }

        [Required]
        public string PassengerType { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
