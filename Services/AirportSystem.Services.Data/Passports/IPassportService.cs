namespace AirportSystem.Services.Data.Passports
{
    using AirportSystem.Services.Data.InputModels;

    public interface IPassportService
    {
        void Edit(PassportInputModel passportInputModel);
    }
}
