namespace AirportSystem.Services.Data.Flights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

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
                FlightStatus = flightInputModel.FlightStatus,
                PlaneId = flightInputModel.PlaneId,
                Price = flightInputModel.Price,
                TravelLineCityId = flightInputModel.TravelLineCityId,
                TravelLineCity2Id = flightInputModel.TravelLineCity2Id,
            };

            var cityName = this.db.Cities.Where(x => x.Id == flightInputModel.TravelLineCityId).Select(x => x.Name).FirstOrDefault();
            var city2Name = this.db.Cities.Where(x => x.Id == flightInputModel.TravelLineCity2Id).Select(x => x.Name).FirstOrDefault();
            flight.TravelLineCityName = cityName;
            flight.TravelLineCity2Name = city2Name;

            this.db.Flights.Add(flight);
            this.db.SaveChanges();
        }

        public IEnumerable<AllFlightsViewModel> GetAll()
        {
            var flights = this.db.Flights.Select(x => new AllFlightsViewModel()
            {
                Id = x.Id,
                TravelLineCityName = x.TravelLineCityName,
                TravelLineCity2Name = x.TravelLineCity2Name,
                DepartureTime = x.DepartureTime,
                ArrivalTime = x.ArrivalTime,
                FlightDuration = x.FlightDuration,
                FlightStatus = x.FlightStatus,
                PlaneId = x.Plane.Id,
                PlaneName = x.Plane.Make,
                TravelLine = x.TravelLine,
                Price = x.Price,
            }).ToList();

            return flights;
        }

        public Flight GetFlightById(int flightId)
        {
            var flight = this.db.Flights.Where(x => x.Id == flightId).FirstOrDefault();

            return flight;
        }

        public IEnumerable<Flight> SearchForFlight(string origin, string destination)
        {
            var flight = this.db.Flights.Where(x => x.TravelLineCityName == origin && x.TravelLineCity2Name == destination).ToList();

            return flight;
        }
    }
}
