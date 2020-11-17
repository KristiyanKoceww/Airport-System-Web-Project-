namespace AirportSystem.Services.Data.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class AvioCompanyInputModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
