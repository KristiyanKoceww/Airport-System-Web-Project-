namespace AirportSystem.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class PaymentViewModel
    {
        [Required]
        public decimal Price { get; set; }

        public int TicketId { get; set; }

        public int FlightId { get; set; }

        [Required]
        public string StripeEmail { get; set; }

        [Required]
        public string StripeToken { get; set; }
    }
}
