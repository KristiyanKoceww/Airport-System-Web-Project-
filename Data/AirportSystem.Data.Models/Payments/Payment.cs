namespace AirportSystem.Data.Models.Payments
{
    using AirportSystem.Data.Models.Payment;
    using AirportSystem.Data.Tickets;

    public class Payment
    {
        public Passenger Passenger { get; set; }

        public string PassengerId { get; set; }

        public Ticket Ticket { get; set; }

        public string TicketId { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}
