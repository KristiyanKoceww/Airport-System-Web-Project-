namespace AirportSystem.Services.Data.Planes
{
    using System.Collections.Generic;

    using AirportSystem.Services.Data.InputModels;
    using PlaneSystem.Data.Planes;

    public interface IPlaneService
    {
        void Create(PlaneInputModel planeInputModel);

        Plane GetPlaneById(string id);

        IEnumerable<Plane> GetAllPlanes();

    }
}
