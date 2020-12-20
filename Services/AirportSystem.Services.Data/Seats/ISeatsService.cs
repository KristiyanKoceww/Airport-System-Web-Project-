namespace AirportSystem.Services.Data.Seats
{
    using System.Collections.Generic;

    using AirportSystem.Data.Models.Planes;

    public interface ISeatsService
    {
        IEnumerable<Seat> Create(bool isAvailable, int seatsCount,int planeId);

        IEnumerable<Seat> GetSeatsByPlaneId(int planeId);
    }
}
