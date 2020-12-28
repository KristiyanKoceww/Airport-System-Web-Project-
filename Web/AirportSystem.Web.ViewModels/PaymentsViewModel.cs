namespace AirportSystem.Web.ViewModels
{
    using AirportSystem.Data.Models.Payment;
    using AirportSystem.Data.Models.Payments;
    using AirportSystem.Data.Tickets;
    using AirportSystem.Services.Mapping;

    public class PaymentsViewModel : IMapFrom<Payment>
    {
        public int PassengerId { get; set; }

        public int TicketId { get; set; }

        public decimal Amount { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public string PassengerFirstName { get; set; }

        public string PassengerLastName { get; set; }

        public TicketRule TicketTicketRule { get; set; }

        public TicketType TicketTicketType { get; set; }
    }
}
