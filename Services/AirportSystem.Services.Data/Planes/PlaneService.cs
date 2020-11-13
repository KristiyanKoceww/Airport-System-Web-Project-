namespace AirportSystem.Services.Data.Planes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Data.InputModels;

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
                Seats = planeInputModel.Seats,
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
                Make = x.Make,
                Model = x.Model,
                Seats = x.Seats,
                PlaneType = x.PlaneType,
                IsPlaneAvailable = x.IsPlaneAvailable,
            }).ToList();

            return planes;
        }

        public Plane GetPlaneById(string id)
        {
            var plane = this.db.Planes.Where(x => x.Id == id).FirstOrDefault();

            return plane;
        }
    }
}
