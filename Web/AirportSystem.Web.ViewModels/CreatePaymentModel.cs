namespace AirportSystem.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreatePaymentModel
    {
        [Required]
        public decimal Price { get; set; }

        public int PassengerId { get; set; }

        public int TicketId { get; set; }
    }
}
