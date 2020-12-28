namespace AirportSystem.Services.Data.Seats
{
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Planes;

    public class SeatsService : ISeatsService
    {
        private readonly ApplicationDbContext db;

        public SeatsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(bool isAvailable, int seatsCount, int planeId)
        {
            var seats = new List<Seat>();
            var plane = this.db.Planes.Where(x => x.Id == planeId).FirstOrDefault();
            var number = 1;
            for (int i = 0; i < seatsCount; i++)
            {
                var seat = new Seat()
                {
                    SeatNumber = number,
                    IsAvailable = isAvailable,
                };
                seats.Add(seat);

                number++;
            }

            foreach (var seat in seats)
            {
                plane.Seats.Add(seat);
            }

            this.db.Seats.AddRangeAsync(seats);
            this.db.SaveChangesAsync();
        }

        public bool CheckSeatsIfIsAvailableAndEquipSeat(Seat seat)
        {
            bool result = true;

            if (seat == null)
            {
                result = false;
            }

            if (seat.IsAvailable == false)
            {
                result = false;
            }

            seat.IsAvailable = false;
            this.db.SaveChangesAsync();

            return result;
        }

        public IEnumerable<Seat> GetSeatsByPlaneId(int planeId)
        {
            var seats = this.db.Seats.Where(x => x.PlaneId == planeId).ToList();

            return seats;
        }
    }
}
