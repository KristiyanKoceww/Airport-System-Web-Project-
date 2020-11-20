namespace AirportSystem.Data.Models.Payments
{
    using AirportSystem.Data.Models.Payment;
    using AirportSystem.Data.Tickets;

    public class Payment
    {
        public virtual Passenger Passenger { get; set; }

        public int PassengerId { get; set; }

        public virtual Ticket Ticket { get; set; }

        public int TicketId { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}
