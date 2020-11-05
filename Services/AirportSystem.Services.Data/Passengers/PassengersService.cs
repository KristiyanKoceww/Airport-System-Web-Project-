namespace AirportSystem.Services.Data.Passengers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;
    using PlaneSystem.Data;
    using PlaneSystem.Data.Passengers;

    public class PassengersService : IPassengersService
    {
        private readonly ApplicationDbContext db;

        public PassengersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(PassengerInputModel passengerInputModel)
        {
            var passenger = new Passenger()
            {
                FirstName = passengerInputModel.FirstName,
                MiddleName = passengerInputModel.MiddleName,
                LastName = passengerInputModel.LastName,
                Address = passengerInputModel.Address,
                Age = passengerInputModel.Age,
                PassportId = passengerInputModel.PassportId,
                Gender = (Gender)Enum.Parse(typeof(Gender), passengerInputModel.Gender),
                PassengerType = (PassengerType)Enum.Parse(typeof(PassengerType), passengerInputModel.PassengerType),
            };

            this.db.Passengers.Add(passenger);
            this.db.SaveChanges();
        }

        public IEnumerable<Passenger> GetAllPassengersByFlightId(string flightId)
        {
            //var passengers = this.db.Passengers.Where(x => x.Tickets.Where(a=>a.FlightId == flightId))
            return null;
        }

        public Passenger GetPassengerById(string id)
        {
            var passenger = this.db.Passengers.Where(x => x.Id == id).FirstOrDefault();

            return passenger;
        }

        public string GetPassengerId(string firstName, string middleName, string lastName)
        {
            var passengerId = this.db.Passengers.Where(x => x.FirstName == firstName && x.MiddleName == middleName && x.LastName == lastName)
                .Select(x => x.Id).FirstOrDefault();

            return passengerId;
        }
    }
}
