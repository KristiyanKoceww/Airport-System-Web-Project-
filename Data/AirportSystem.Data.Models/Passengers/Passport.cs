namespace AirportSystem.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Common.Models;

    public class Passport
    {
        [Required]
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ExpiresOn { get; set; }

        public string Country { get; set; }
    }
}
