namespace AirportSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AirportSystem.Data.Models.Airports;
    using Newtonsoft.Json;

    internal class AirportSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Airports.Any())
            {
                return;
            }

            var airports = new List<Airport>();

            using (StreamReader r = File.OpenText(@"C:\Users\User\Desktop\Airport System WebProject\Data\AirportSystem.Data\JsonDb\Airports.json"))
            {
                string json = r.ReadToEnd();
                airports = JsonConvert.DeserializeObject<List<Airport>>(json);
            }

            await dbContext.Airports.AddRangeAsync(airports);

            await dbContext.SaveChangesAsync();
        }
    }
}
