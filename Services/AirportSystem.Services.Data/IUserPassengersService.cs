namespace AirportSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IUserPassengersService
    {
        void Create(string userId, string passengerId);
    }
}
