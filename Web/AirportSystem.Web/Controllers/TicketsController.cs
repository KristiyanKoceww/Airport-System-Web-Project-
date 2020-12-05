namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Data.Tickets;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Luggages;
    using AirportSystem.Services.Data.Passengers;
    using AirportSystem.Services.Data.Tickets;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;
  

    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;
        private readonly IFlightService flightService;
        private readonly IPassengersService passengersService;
        private readonly ILuggageService luggageService;

        public TicketsController(
            ITicketService ticketService,
            IFlightService flightService,
            IPassengersService passengersService,
            ILuggageService luggageService)
        {
            this.ticketService = ticketService;
            this.flightService = flightService;
            this.passengersService = passengersService;
            this.luggageService = luggageService;
        }

        public IActionResult BookFlight(int id)
        {
            var flight = this.flightService.GetFlightById(id);

            var viewModel = new BookTicketViewModel();

            viewModel.FlightId = flight.Id;
            viewModel.Price = flight.Price;

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult BookFlight(TicketInputModel input)
        {
            this.ticketService.Create(input, input.FlightId);

            var ticketId = this.ticketService.GetTicketByFlightId(input.FlightId);

            var ticket = this.ticketService.GetTicketById(ticketId);

            return this.RedirectToAction("UserTicket", "Tickets", ticket);
        }

        public IActionResult UserTicket(Ticket ticket)
        {
            var passenger = this.passengersService.GetPassengerById(ticket.PassengerId);
            var flight = this.flightService.GetFlightById(ticket.FlightId);
            var luggage = this.luggageService.GetLuggageById(ticket.LuggageId);

            var viewModel = new UserTicketViewModel()
            {
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

            return this.View(viewModel);
        }
    }
}
