namespace AirportSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Mapping;

    public class AllPlanesViewModel : IMapFrom<Plane>
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Seats { get; set; }

        public bool IsPlaneAvailable { get; set; }

        public virtual PlaneType PlaneType { get; set; }

        public int AvioCompanyId { get; set; }

        public string AvioCompanyName { get; set; }

        public virtual AvioCompany AvioCompany { get; set; }
    }
}
