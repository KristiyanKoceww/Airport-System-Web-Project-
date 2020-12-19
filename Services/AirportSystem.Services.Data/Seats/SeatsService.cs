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

        public IEnumerable<Seat> Create(bool isAvailable, int seatsCount,int planeId)
        {
            var seats = new List<Seat>();
            var plane = this.db.Planes.Where(x => x.Id == planeId).FirstOrDefault();

            for (int i = 0; i < seatsCount; i++)
            {
                var seat = new Seat()
                {
                    IsAvailable = true,
                };
                seats.Add(seat);
            }

            foreach (var seat in seats)
            {
                plane.Seats.Add(seat);
            }

            this.db.Seats.AddRange(seats);
            this.db.SaveChanges();

            return seats;
        }
    }
}
