namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Tickets;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;

        public TicketsController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public IActionResult BookFlight()
        {
            var viewModel = new BookTicketViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult BookFlight(TicketInputModel input)
        {
            this.ticketService.Create(input);

            return this.View();

            // return this.Redirect("Tickets/UserTicket");
        }

        public IActionResult UserTicket()
        {
            return this.View();
        }
    }
}
