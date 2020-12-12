namespace AirportSystem.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class PaymentModel
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string StripeEmail { get; set; }

        [Required]
        public string StripeToken { get; set; }

        public int PassengerId { get; set; }

        public int TicketId { get; set; }
    }
}
