namespace AirportSystem.Services.Data.Tests.Airports
{
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Data.Airports;
    using AirportSystem.Services.Data.InputModels;
    using Xunit;

    public class AvioCompaniesServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task EnsureAddPlanesToAvioCompanyWorkProperly()
        {
            var service = new AvioCompanyService(this.DbContext);

            var plane = new Plane()
            {
                Id = 1,
                Make = "Boeing",
                Model = "Airbus",
                IsPlaneAvailable = true,
            };

            var plane2 = new Plane()
            {
                Id = 2,
                Make = "Boeing",
                Model = "Airbus",
                IsPlaneAvailable = true,
            };

            var avioCompany = new AvioCompany()
            {
                Name = "Berlin aviocompany",
                Id = 1,
            };

            await this.DbContext.Planes.AddAsync(plane);
            await this.DbContext.Planes.AddAsync(plane2);
            await this.DbContext.AvioCompanies.AddAsync(avioCompany);
            await this.DbContext.SaveChangesAsync();
            var company = service.FindCompanyById(1);
            company.Planes.Add(plane);
            company.Planes.Add(plane2);

            var planesCount = this.DbContext.Planes.Count();

            Assert.Equal(2, planesCount);
            Assert.NotNull(plane);
            Assert.NotNull(company);
            Assert.NotNull(company.Planes);
            Assert.Equal(2, company.Planes.Count());
        }

        [Fact]
        public async Task EnsureGetCompanyByIdWorkProperly()
        {
            var service = new AvioCompanyService(this.DbContext);

            var avioCompany = new AvioCompany()
            {
                Name = "Berlin aviocompany",
                Id = 1,
            };

            await this.DbContext.AvioCompanies.AddAsync(avioCompany);
            await this.DbContext.SaveChangesAsync();

            var company = service.FindCompanyById(1);

            Assert.Equal("Berlin aviocompany", company.Name);
        }

        [Fact]
        public async Task EnsureGetCompanyByIdReturnNullWhenNoMatchIsFound()
        {
            var service = new AvioCompanyService(this.DbContext);

            var avioCompany = new AvioCompany()
            {
                Name = "Berlin aviocompany",
                Id = 1,
            };

            await this.DbContext.AvioCompanies.AddAsync(avioCompany);
            await this.DbContext.SaveChangesAsync();

            var company = service.FindCompanyById(2);

            Assert.Null(company);
        }

        [Fact]
        public void EnsureGetCompanyByIdReturnNullWhenDbIsEmpty()
        {
            var service = new AvioCompanyService(this.DbContext);

            var company = service.FindCompanyById(1);

            Assert.Null(company);
        }

        [Fact]
        public void EnsureCreateCompanyWorkProperly()
        {
            var service = new AvioCompanyService(this.DbContext);

            var avioCompany = new AvioCompanyInputModel()
            {
                Name = "Berlin aviocompany",
            };
            var avioCompany2 = new AvioCompanyInputModel()
            {
                Name = "France aviocompany",
            };

            service.Create(avioCompany);
            service.Create(avioCompany2);

            var company = this.DbContext.AvioCompanies.Count();

            Assert.Equal(2, company);
        }

        [Fact]
        public void EnsureGetAllCompanyWorkProperly()
        {
            var service = new AvioCompanyService(this.DbContext);

            var avioCompany = new AvioCompanyInputModel()
            {
                Name = "Berlin aviocompany",
            };
            var avioCompany2 = new AvioCompanyInputModel()
            {
                Name = "France aviocompany",
            };

            service.Create(avioCompany);
            service.Create(avioCompany2);

            var company = service.GetAll();

            Assert.Equal(2, company.Count());
        }

        [Fact]
        public void EnsureGetAllCompanyReturnZeroWhenDbIsEmpty()
        {
            var service = new AvioCompanyService(this.DbContext);

            var company = service.GetAll();

            Assert.Empty(company);
        }
    }
}
