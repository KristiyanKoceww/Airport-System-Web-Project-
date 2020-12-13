namespace AirportSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    internal class FlightsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Flights.Any())
            {
                return;
            }

            var flights = new List<Flight>();

            using (StreamReader r = File.OpenText(@"C:\Users\User\Desktop\Airport System WebProject\Data\AirportSystem.Data\JsonDb\Flights.json"))
            {
                string json = r.ReadToEnd();
                flights = JsonConvert.DeserializeObject<List<Flight>>(json);
            }

            await dbContext.Flights.AddRangeAsync(flights);

            await dbContext.SaveChangesAsync();
        }
    }
}
