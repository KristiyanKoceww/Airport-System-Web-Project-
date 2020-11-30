namespace AirportSystem.Services.Data.Passengers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Passengers;
    using AirportSystem.Data.Passengers;
    using AirportSystem.Services.Data.InputModels;

    public class PassengersService : IPassengersService
    {
        private readonly ApplicationDbContext db;

        public PassengersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(PassengerInputModel passengerInputModel)
        {
            var passport = new Passport()
            {
                Id = passengerInputModel.PassportId,
                CreatedOn = DateTime.UtcNow,
                ExpiresOn = DateTime.UtcNow.AddDays(365),
                Country = "Null",
                Nationality = "Null",
            };

            var passenger = new Passenger()
            {
                FirstName = passengerInputModel.FirstName,
                MiddleName = passengerInputModel.MiddleName,
                LastName = passengerInputModel.LastName,
                Address = passengerInputModel.Address,
                Age = passengerInputModel.Age,
                Phone = passengerInputModel.Phone,
                PassportId = passengerInputModel.PassportId,
                Gender = passengerInputModel.Gender,
                PassengerType = passengerInputModel.PassengerType,
            };

            this.db.Passengers.Add(passenger);
            this.db.Passports.Add(passport);
            this.db.SaveChanges();
        }

        public IEnumerable<Passenger> GetAll()
        {
            var passengers = this.db.Passengers.Select(x => new Passenger
            {
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                Address = x.Address,
                Age = x.Age,
                Phone = x.Phone,
            }).ToList();

            return passengers;
        }

        // TODO
        public IEnumerable<Passenger> GetAllPassengersByFlightId(int flightId)
        {
            var passengers = this.db.Flights.Where(x => x.Id == flightId).Select(x => x.Passengers).ToList();
            return (IEnumerable<Passenger>)passengers;
        }

        public Passenger GetPassengerById(int id)
        {
            var passenger = this.db.Passengers.Where(x => x.Id == id).FirstOrDefault();

            return passenger;
        }

        public UserPassenger GetPassengerByUserId(string id)
        {
            var passenger = this.db.UsersPassengers.Where(x => x.UserId == id).FirstOrDefault();

            return passenger;
        }

        public int GetPassengerId(string firstName, string middleName, string lastName)
        {
            var passengerId = this.db.Passengers.Where(x => x.FirstName == firstName && x.MiddleName == middleName && x.LastName == lastName)
                .Select(x => x.Id).FirstOrDefault();

            return passengerId;
        }
    }
}
