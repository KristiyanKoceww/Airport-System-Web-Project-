namespace AirportSystem.Services.Data.Airports
{
    using System.Collections.Generic;

    using AirportSystem.Data.Models.Airports;
    using AirportSystem.Services.Data.InputModels;

    public interface IAvioCompanyService
    {
        void Create(AvioCompanyInputModel avioCompanyInputModel);

        IEnumerable<AvioCompany> GetAll();
    }
}
