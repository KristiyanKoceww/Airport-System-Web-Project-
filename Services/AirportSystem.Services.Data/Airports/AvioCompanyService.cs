namespace AirportSystem.Services.Data.Airports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Data.InputModels;

    public class AvioCompanyService : IAvioCompanyService
    {
        private readonly ApplicationDbContext db;

        public AvioCompanyService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddPlanes(AddPlaneToAvioCompanyInputModel addPlaneToAvioCompanyInputModel)
        {
            var company = this.db.AvioCompanies.Find(addPlaneToAvioCompanyInputModel.AvioCompanyId);

            var plane = new Plane()
            {
                Make = addPlaneToAvioCompanyInputModel.Make,
                Model = addPlaneToAvioCompanyInputModel.Model,
                PlaneType = (PlaneType)Enum.Parse(typeof(PlaneType), addPlaneToAvioCompanyInputModel.Type),
                IsPlaneAvailable = addPlaneToAvioCompanyInputModel.IsPlaneAvailable,
            };

            this.db.Planes.Add(plane);
            company.Planes.Add(plane);
            this.db.SaveChanges();
        }

        public void Create(AvioCompanyInputModel avioCompanyInputModel)
        {
            var avioCompany = new AvioCompany()
            {
                Name = avioCompanyInputModel.Name,
                Planes = avioCompanyInputModel.Planes,
            };

            this.db.AvioCompanies.Add(avioCompany);
            this.db.SaveChanges();
        }

        public AvioCompany FindCompanyById(int id)
        {
            var company = this.db.AvioCompanies.Find(id);

            return company;
        }

        public IEnumerable<AvioCompany> GetAll()
        {
            var companies = this.db.AvioCompanies.Select(x => new AvioCompany
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return companies;
        }
    }
}
