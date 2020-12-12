using System.ComponentModel.DataAnnotations;

namespace AirportSystem.Web.ViewModels
{
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
