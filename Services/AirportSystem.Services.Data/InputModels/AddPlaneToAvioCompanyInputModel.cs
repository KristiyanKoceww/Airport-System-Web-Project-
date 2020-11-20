using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirportSystem.Services.Data.InputModels
{
    public class AddPlaneToAvioCompanyInputModel
    {
        [Required]
        [MaxLength(30)]
        public string Make { get; set; }

        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public bool IsPlaneAvailable { get; set; }

        public int AvioCompanyId { get; set; }
    }
}
