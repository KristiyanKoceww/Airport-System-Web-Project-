namespace AirportSystem.Data.Models
{
    using System;

    using AirportSystem.Data.Common.Models;
    using AirportSystem.Data.Models.Destinations;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Extension { get; set; }

        //// The contents of the image is in the file system
        public string RemoteImageUrl { get; set; }

        public string CityId { get; set; }

        public virtual City City { get; set; }
    }
}
