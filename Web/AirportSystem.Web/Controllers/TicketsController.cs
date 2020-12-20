namespace AirportSystem.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data.Tickets;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Luggages;
    using AirportSystem.Services.Data.Passengers;
    using AirportSystem.Services.Data.Seats;
    using AirportSystem.Services.Data.Tickets;
    using AirportSystem.Services.Messaging;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;
        private readonly IFlightService flightService;
        private readonly IPassengersService passengersService;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IEmailSender emailSender;
        private readonly ILuggageService luggageService;
        private readonly ISeatsService seatsService;

        public TicketsController(
            ITicketService ticketService,
            IFlightService flightService,
            IPassengersService passengersService,
            IHostingEnvironment hostingEnvironment,
            IEmailSender emailSender,
            ILuggageService luggageService,
            ISeatsService seatsService)
        {
            this.ticketService = ticketService;
            this.flightService = flightService;
            this.passengersService = passengersService;
            this.hostingEnvironment = hostingEnvironment;
            this.emailSender = emailSender;
            this.luggageService = luggageService;
            this.seatsService = seatsService;
        }

        public async Task<IActionResult> BookFlight(int id)
        {
            var flight = this.flightService.GetFlightById(id);

            var viewModel = new BookTicketViewModel();

            viewModel.FlightId = flight.Id;
            viewModel.Price = flight.Price;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> BookFlight(TicketInputModel input)
        {
            this.ticketService.Create(input, input.FlightId);

            var flight = this.flightService.GetFlightById(input.FlightId);

            var ticketId = this.ticketService.GetTicketByFlightId(input.FlightId);

            var ticket = this.ticketService.GetTicketById(ticketId);

            var passenger = this.passengersService.GetPassengerById(input.PassengerId);

            var luggage = this.luggageService.GetLuggageByPassengerId(input.PassengerId);

            if (input.TicketRule == "2")
            {
                flight.Price *= 2;
            }

            switch (input.TicketType)
            {
                case "1":
                    flight.Price = flight.Price - (flight.Price * 0.2M);
                    break;
                case "2":
                    flight.Price *= 1.5M;
                    break;
                case "3":
                    flight.Price *= 1.25M;
                    break;
            }

            var viewModel = new UserTicketViewModel()
            {
                LuggageType = luggage.LuggageType.ToString(),
                LuggageWeight = luggage.Weight,
                TicketId = ticketId,
                PassengerId = ticket.PassengerId,
                PassengerName = passenger.FirstName,
                Price = flight.Price,
                FlightArrivalTime = flight.ArrivalTime,
                FlightDepartureTime = flight.DepartureTime,
                SeatNumber = ticket.SeatNumber,
                TicketRule = ticket.TicketRule,
                TicketType = ticket.TicketType,
                FlightId = flight.Id,
                LuggageId = ticket.LuggageId,
                Origin = flight.TravelLineCityName,
                Destination = flight.TravelLineCity2Name,
            };

            return this.RedirectToAction("Confirmation", viewModel);
        }

        public async Task<IActionResult> UserTicket(decimal price, int passengerId, int ticketId)
        {
            var ticket = this.ticketService.GetTicketById(ticketId);
            var passenger = this.passengersService.GetPassengerById(passengerId);
            var luggage = this.luggageService.GetLuggageByPassengerId(passengerId);

            var flight = this.flightService.GetFlightById(ticket.FlightId);

            var viewModel = new UserTicketViewModel()
            {
                LuggageType = luggage.LuggageType.ToString(),
                LuggageWeight = luggage.Weight,
                TicketId = ticketId,
                PassengerId = ticket.PassengerId,
                PassengerName = passenger.FirstName,
                Price = price,
                FlightArrivalTime = flight.ArrivalTime,
                FlightDepartureTime = flight.DepartureTime,
                SeatNumber = ticket.SeatNumber,
                TicketRule = ticket.TicketRule,
                TicketType = ticket.TicketType,
                FlightId = flight.Id,
                LuggageId = ticket.LuggageId,
                Origin = flight.TravelLineCityName,
                Destination = flight.TravelLineCity2Name,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Confirmation(UserTicketViewModel viewModel)
        {
            return this.View(viewModel);
        }

        public async Task<IActionResult> BookSeats(int planeId)
        {
            var seats = this.seatsService.GetSeatsByPlaneId(planeId);

            var viewModel = new SeatsViewModel
            {
                PlaneId = planeId,
                IsAvailable = true,
            };

            return this.View(viewModel);
        }
    }
}