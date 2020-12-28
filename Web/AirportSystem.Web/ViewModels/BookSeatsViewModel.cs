namespace AirportSystem.Web.ViewModels
{
    using System.Collections.Generic;

    using AirportSystem.Data.Models.Planes;

    public class BookSeatsViewModel
    {
        public string Title { get; set; }

        public int Seats { get; set; }

        public Dictionary<Seat, bool> IsSeatAvailable { get; set; }
    }
}
