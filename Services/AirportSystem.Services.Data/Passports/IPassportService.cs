namespace AirportSystem.Services.Data.Passports
{
    using AirportSystem.Data;
    using AirportSystem.Services.Data.InputModels;

    public interface IPassportService
    {
        void Edit(PassportInputModel passportInputModel);

        Passport FindPassportById(string passportId);
    }
}
