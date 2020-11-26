namespace AirportSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AirportSystem.Data.Models.Destinations;
    using AirportSystem.Services.Mapping;

    public class AllCityViewModel : IMapFrom<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public virtual Country Country { get; set; }
    }
}
