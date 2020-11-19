namespace AirportSystem.Services.Data.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirportSystem.Data.Planes;

    public class AvioCompanyInputModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<Plane> Planes { get; set; }
    }
}
