namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class PaymentInputModel
    {
        [Required]
        public string PassengerId { get; set; }

        [Required]
        public string TicketId { get; set; }

        [Required]
        public string PaymentStatus { get; set; }
    }
}
