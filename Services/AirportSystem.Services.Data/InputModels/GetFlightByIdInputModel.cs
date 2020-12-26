namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class GetFlightByIdInputModel
    {
        [Required]
        [Display(Name = "Enter flight identifination number")]
        public int Id { get; set; }
    }
}
