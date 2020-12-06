namespace AirportSystem.Services.Data.Planes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Planes;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

    public class PlaneService : IPlaneService
    {
        private readonly ApplicationDbContext db;

        public PlaneService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(PlaneInputModel planeInputModel)
        {
            var plane = new Plane()
            {
                Make = planeInputModel.Make,
                Model = planeInputModel.Model,
                PlaneType = (PlaneType)Enum.Parse(typeof(PlaneType), planeInputModel.Type),
                IsPlaneAvailable = planeInputModel.IsPlaneAvailable,
            };

            this.db.Planes.Add(plane);
            this.db.SaveChanges();
        }

        public IEnumerable<Plane> GetAllPlanes()
        {
            var planes = this.db.Planes.Select(x => new Plane
            {
                Id = x.Id,
                Make = x.Make,
                Model = x.Model,
                PlaneType = x.PlaneType,
                IsPlaneAvailable = x.IsPlaneAvailable,
                Seats = x.Seats.Select(x => new Seat()
                {
                    Id = x.Id,
                    IsAvailable = x.IsAvailable,
                }).ToList(),
            }).ToList();

            return planes;
        }

        public Plane GetPlaneById(int id)
        {
            var plane = this.db.Planes.Where(x => x.Id == id).FirstOrDefault();

            return plane;
        }
    }
}
