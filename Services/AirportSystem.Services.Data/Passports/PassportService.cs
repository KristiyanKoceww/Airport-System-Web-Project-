namespace AirportSystem.Services.Data.Passports
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;

    public class PassportService : IPassportService
    {
        private readonly ApplicationDbContext db;

        public PassportService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Edit(PassportInputModel passportInputModel)
        {
            var passportToEdit = this.db.Passports.Find(passportInputModel.Id);
            passportToEdit.CreatedOn = passportInputModel.CreatedOn;
            passportToEdit.ExpiresOn = passportInputModel.ExpiresOn;

            this.db.Passports.Update(passportToEdit);
            this.db.SaveChanges();
        }
    }
}
