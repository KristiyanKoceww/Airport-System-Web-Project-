using AirportSystem.Data.Common.Models;

namespace AirportSystem.Data.Models.Planes
{
    public class Seat : BaseModel<int>
    {
        public bool IsAvailable { get; set; }
    }
}
