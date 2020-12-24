namespace AirportSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AirportSystem.Data;
    using AirportSystem.Services.Mapping;

    public class SearchLuggageViewModel : IMapFrom<Luggage>
    {
        public int Id { get; set; }

        public LuggageType LuggageType { get; set; }

        public int PassengerId { get; set; }

        public string PassengerFirstName { get; set; }

        public decimal Weight { get; set; }
    }
}
