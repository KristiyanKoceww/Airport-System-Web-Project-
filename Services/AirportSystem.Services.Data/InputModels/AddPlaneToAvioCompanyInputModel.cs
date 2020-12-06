namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddPlaneToAvioCompanyInputModel
    {
        [Required]
        [MaxLength(30)]
        public string Make { get; set; }

        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        public int SeatsCount { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public bool IsPlaneAvailable { get; set; }

        public int AvioCompanyId { get; set; }
    }
}
