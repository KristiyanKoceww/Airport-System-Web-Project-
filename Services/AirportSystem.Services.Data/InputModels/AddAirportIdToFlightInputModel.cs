namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddAirportIdToFlightInputModel
    {
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "FlightId contains only digits!")]
        public string FlightId { get; set; }
    }
}
