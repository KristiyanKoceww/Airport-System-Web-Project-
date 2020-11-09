namespace AirportSystem.Data.Models.Passengers
{
    using PlaneSystem.Data;

    public class IUserPassenger
    {
        public string PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}
