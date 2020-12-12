using System.ComponentModel.DataAnnotations;

namespace AirportSystem.Web.ViewModels
{
    public class CreatePaymentModel
    {
        [Required]
        public decimal Price { get; set; }

        public int PassengerId { get; set; }

        public int TicketId { get; set; }
    }
}
