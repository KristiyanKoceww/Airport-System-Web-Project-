namespace AirportSystem.Data.Models.Payments
{
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Models.Payment;
    using AirportSystem.Data.Tickets;

    public class Payment
    {
        [Required]
        public int PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }

        [Required]
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}
