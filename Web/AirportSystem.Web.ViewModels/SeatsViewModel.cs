namespace AirportSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AirportSystem.Data.Models.Planes;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Mapping;

    public class SeatsViewModel : IMapFrom<Seat>
    {
        public bool IsAvailable { get; set; }

        public int PlaneId { get; set; }

        public virtual Plane Plane { get; set; }
    }
}
