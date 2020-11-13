namespace AirportSystem.Services.Data.Planes
{
    using System.Collections.Generic;

    using AirportSystem.Data.Planes;
    using AirportSystem.Services.Data.InputModels;

    public interface IPlaneService
    {
        void Create(PlaneInputModel planeInputModel);

        Plane GetPlaneById(string id);

        IEnumerable<Plane> GetAllPlanes();
    }
}
