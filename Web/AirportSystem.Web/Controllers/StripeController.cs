namespace AirportSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AirportSystem.Data.Models;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Passengers;
    using AirportSystem.Services.Data.Payments;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Stripe;

    public class StripeController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPaymentService paymentService;
        private readonly IPassengersService passengersService;

        public StripeController(
            UserManager<ApplicationUser> userManager,
            IPaymentService paymentService,
            IPassengersService passengersService)
        {
            this.userManager = userManager;
            this.paymentService = paymentService;
            this.passengersService = passengersService;
        }

        public async Task<IActionResult> Charge(decimal price, int ticketId)
        {
            var viewModel = new PaymentViewModel();

            viewModel.Price = price;
            viewModel.TicketId = ticketId;
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Charge(PaymentModel paymentInputModel)
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

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = (int)paymentInputModel.Price * 100,
                Description = "Test Payment",
                Currency = "BGN",
                Customer = customer.Id,
                ReceiptEmail = paymentInputModel.StripeEmail,
                Metadata = new Dictionary<string, string>()
                {
                    { "PassengerId", passenger.PassengerId.ToString() },
                    { "TicketId" , paymentInputModel.TicketId.ToString() },
                },
            });

            if (charge.Status == "succeeded")
            {
                string balanceTransactionId = charge.BalanceTransactionId;

                var paymentModel = new PaymentInputModel()
                {
                    Amount = paymentInputModel.Price,
                    PassengerId = passenger.PassengerId,
                    TicketId = paymentInputModel.TicketId,
                    PaymentStatus = "PaymentRecieved",
                };

                this.paymentService.Create(paymentModel);
                return this.RedirectToAction("UserTicket", "Tickets", new { price = paymentModel.Amount, passengerId = paymentModel.PassengerId, ticketId = paymentModel.TicketId });
            }

            return this.View();
        }
    }
}
