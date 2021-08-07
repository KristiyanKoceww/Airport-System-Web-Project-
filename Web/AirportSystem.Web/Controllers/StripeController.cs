namespace AirportSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AirportSystem.Data.Models;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Passengers;
    using AirportSystem.Services.Data.Payments;
    using AirportSystem.Services.Data.Tickets;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Stripe;

    [Authorize]
    public class StripeController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPaymentService paymentService;
        private readonly IPassengersService passengersService;
        private readonly ITicketService ticketService;
        private readonly IFlightService flightService;

        public StripeController(
            UserManager<ApplicationUser> userManager,
            IPaymentService paymentService,
            IPassengersService passengersService,
            ITicketService ticketService,
            IFlightService flightService)
        {
            this.userManager = userManager;
            this.paymentService = paymentService;
            this.passengersService = passengersService;
            this.ticketService = ticketService;
            this.flightService = flightService;
        }

        public IActionResult Charge(decimal price, int ticketId)
        {
            var viewModel = new PaymentViewModel
            {
                Price = price,
                TicketId = ticketId,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Charge(PaymentModel paymentInputModel)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = paymentInputModel.StripeEmail,
                Source = paymentInputModel.StripeToken,
            });

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var passenger = this.passengersService.GetPassengerByUserId(userId);

            var ticket = this.ticketService.GetTicketById(paymentInputModel.TicketId);
            decimal flightPrice = 0;
            if (ticket != null)
            {
                flightPrice = this.flightService.GetFlightById(ticket.FlightId).Price;
            }
            else
            {
                return this.View();
            }

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = (int)flightPrice * 100,
                Description = "Test Payment",
                Currency = "BGN",
                Customer = customer.Id,
                ReceiptEmail = paymentInputModel.StripeEmail,
                Metadata = new Dictionary<string, string>()
                {
                    { "PassengerId", passenger.PassengerId.ToString() },
                    { "TicketId", paymentInputModel.TicketId.ToString() },
                },
            });

            if (charge.Status == "succeeded")
            {
                string balanceTransactionId = charge.BalanceTransactionId;

                var paymentModel = new PaymentInputModel()
                {
                    Amount = flightPrice,
                    PassengerId = passenger.PassengerId,
                    TicketId = paymentInputModel.TicketId,
                    PaymentStatus = "PaymentRecieved",
                };

                this.paymentService.Create(paymentModel);
                return this.RedirectToAction("UserTicket", "Tickets", new { price = flightPrice, passengerId = paymentModel.PassengerId, ticketId = paymentModel.TicketId });
            }

            return this.View();
        }

        public IActionResult GetAllPayments()
        {
            var payments = this.paymentService.GetAll();

            return this.View(payments);
        }
    }
}
