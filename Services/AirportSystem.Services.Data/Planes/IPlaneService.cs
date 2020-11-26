namespace AirportSystem.Services.Data.Planes
{
    using System.Collections.Generic;

    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

    public interface IPlaneService
    {
        void Create(PlaneInputModel planeInputModel);

        Plane GetPlaneById(int id);

        IEnumerable<Plane> GetAllPlanes();
    }
}
