namespace PlaneSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

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
