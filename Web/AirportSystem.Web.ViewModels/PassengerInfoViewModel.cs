namespace AirportSystem.Web.ViewModels
{
    using System.Collections.Generic;

    using AirportSystem.Data;
    using AirportSystem.Services.Mapping;

    public class PassengerInfoViewModel : IMapFrom<Passenger>
    {
        public int PassengerId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string PassportId { get; set; }

        public IEnumerable<Luggage> Luggages { get; set; }
    }
}
