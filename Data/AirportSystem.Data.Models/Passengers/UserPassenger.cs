namespace AirportSystem.Data.Models.Passengers
{
    public class UserPassenger
    {
        public int PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
