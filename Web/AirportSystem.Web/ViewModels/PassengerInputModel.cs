namespace AirportSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using PlaneSystem.Data;
    using PlaneSystem.Data.Passengers;

    public class PassengerInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string MiddleName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string LastName { get; set; }

        [Required]
        [Range(18, 85)]
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
        public string PassportId { get; set; }

        public PassengerType PassengerType { get; set; }

        public Gender Gender { get; set; }
    }
}
