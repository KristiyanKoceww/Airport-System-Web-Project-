namespace AirportSystem.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Passport
    {
        public Passport()
        {
            // this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ExpiresOn { get; set; }
    }
}
