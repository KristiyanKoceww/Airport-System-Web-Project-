namespace AirportSystem.Services.Data.Airports
{
    using System.Collections.Generic;
    using System.Linq;
    using AirportSystem.Data;
    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Services.Data.InputModels;

    public class AvioCompanyService : IAvioCompanyService
    {
        private readonly ApplicationDbContext db;

        public AvioCompanyService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(AvioCompanyInputModel avioCompanyInputModel)
        {
            var avioCompany = new AvioCompany()
            {
                Name = avioCompanyInputModel.Name,
            };

            this.db.AvioCompanies.Add(avioCompany);
            this.db.SaveChanges();
        }

        public IEnumerable<AvioCompany> GetAll()
        {
            var companies = this.db.AvioCompanies.Select(x => new AvioCompany
            {
                Name = x.Name,
            }).ToList();

            return companies;
        }
    }
}
