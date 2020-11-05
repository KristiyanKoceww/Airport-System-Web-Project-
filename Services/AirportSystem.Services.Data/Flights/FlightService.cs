namespace AirportSystem.Services.Data.Flights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;
    using PlaneSystem.Data.Flight;

    public class FlightService : IFlightService
    {
        private readonly ApplicationDbContext db;

        public FlightService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(FlightInputModel flightInputModel)
        {
            // TODO think how to map others properties
            var flight = new Flight()
            {
                DepartureTime = flightInputModel.DepartureTime,
                ArrivalTime = flightInputModel.ArrivalTime,
                FlightDuration = flightInputModel.FlightDuration,
                FlightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), flightInputModel.FlightStatus),
            };

            this.db.Flights.Add(flight);
            this.db.SaveChanges();
        }

        public IEnumerable<Flight> GetAll()
        {
            var flights = this.db.Flights.Select(x => new Flight()
            {
                DepartureTime = x.DepartureTime,
                ArrivalTime = x.ArrivalTime,
                FlightDuration = x.FlightDuration,
                FlightStatus = x.FlightStatus,
            }).ToList();

            return flights;
        }

        public Flight GetFlightById(string flightId)
        {
            var flight = this.db.Flights.Where(x => x.Id == flightId).FirstOrDefault();

            return flight;
        }
    }
}
