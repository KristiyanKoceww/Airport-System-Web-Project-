namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class PaymentInputModel
    {
        [Required]
        public int PassengerId { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        public string PaymentStatus { get; set; }

        public decimal Amount { get; set; }
    }
}
