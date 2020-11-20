namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddAirportIdToFlightInputModel
    {
        [Required]
        public string FlightId { get; set; }
    }
}
