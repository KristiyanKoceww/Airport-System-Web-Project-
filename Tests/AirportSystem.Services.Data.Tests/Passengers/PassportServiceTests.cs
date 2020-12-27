namespace AirportSystem.Services.Data.Tests.Passengers
{
    using System;
    using System.Threading.Tasks;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Passports;
    using Xunit;

   public class PassportServiceTests : BaseServiceTests
    {
        [Fact]
        public void EnsureEditPassportIsWorkingCorrect()
        {
            var service = new PassportService(this.DbContext);

            var passportToEdit = new Passport()
            {
                Id = "233",
                CreatedOn = DateTime.UtcNow,
                ExpiresOn = DateTime.UtcNow.AddDays(365),
                Country = "Null",
                Nationality = "Null",
            };

            this.DbContext.Passports.Add(passportToEdit);
            this.DbContext.SaveChanges();

            var newPassportInfo = new PassportInputModel()
            {
                Id = "233",
                CreatedOn = DateTime.UtcNow,
                ExpiresOn = DateTime.UtcNow.AddDays(365),
                Country = "Bulgaria",
                Nationality = "Bulgarian",
            };

            service.Edit(newPassportInfo);

            Assert.Equal(passportToEdit.Country,newPassportInfo.Country);
            Assert.Equal(passportToEdit.Nationality,newPassportInfo.Nationality);
        }

        [Fact]
        public void EnsureGetFindPassportByIdWorkCorect()
        {
            var service = new PassportService(this.DbContext);

            var passportToEdit = new Passport()
            {
                Id = "233",
                CreatedOn = DateTime.UtcNow,
                ExpiresOn = DateTime.UtcNow.AddDays(365),
                Country = "Null",
                Nationality = "Null",
            };

            this.DbContext.Passports.Add(passportToEdit);
            this.DbContext.SaveChanges();

            var newPassportInfo = new PassportInputModel()
            {
                Id = "233",
                CreatedOn = DateTime.UtcNow,
                ExpiresOn = DateTime.UtcNow.AddDays(365),
                Country = "Bulgaria",
                Nationality = "Bulgarian",
            };

            service.Edit(newPassportInfo);

            var passportId = "233";
            var foundPassport = service.FindPassportById(passportId);

            Assert.NotNull(foundPassport);
            Assert.Equal(passportId,foundPassport.Id);

        }

        [Fact]
        public void EnsureGetFindPassportByIdReturnNullWhenNoMatch()
        {
            var service = new PassportService(this.DbContext);

            var passportToEdit = new Passport()
            {
                Id = "233",
                CreatedOn = DateTime.UtcNow,
                ExpiresOn = DateTime.UtcNow.AddDays(365),
                Country = "Null",
                Nationality = "Null",
            };

            this.DbContext.Passports.Add(passportToEdit);
            this.DbContext.SaveChanges();

            var newPassportInfo = new PassportInputModel()
            {
                Id = "233",
                CreatedOn = DateTime.UtcNow,
                ExpiresOn = DateTime.UtcNow.AddDays(365),
                Country = "Bulgaria",
                Nationality = "Bulgarian",
            };

            service.Edit(newPassportInfo);

            var passportId = "244";
            var foundPassport = service.FindPassportById(passportId);

            Assert.Null(foundPassport);
        }
    }
}
