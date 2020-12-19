namespace AirportSystem.Data.Models.Planes
{
    using AirportSystem.Data.Common.Models;

    public class Seat : BaseModel<int>
    {
        public bool IsAvailable { get; set; }
    }
}
