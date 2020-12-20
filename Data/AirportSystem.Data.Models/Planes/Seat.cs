namespace AirportSystem.Data.Models.Planes
{
    using AirportSystem.Data.Common.Models;
    using AirportSystem.Data.Planes;

    public class Seat : BaseModel<int>
    {
        public bool IsAvailable { get; set; }

        public int PlaneId { get; set; }

        public virtual Plane Plane { get; set; }
    }
}
