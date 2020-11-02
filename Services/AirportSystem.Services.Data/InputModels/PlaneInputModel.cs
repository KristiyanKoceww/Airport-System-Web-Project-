namespace AirportSystem.Services.Data.InputModels
{
    public class PlaneInputModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Seats { get; set; }

        public string Type { get; set; }

        public bool IsPlaneAvailable { get; set; }
    }
}
