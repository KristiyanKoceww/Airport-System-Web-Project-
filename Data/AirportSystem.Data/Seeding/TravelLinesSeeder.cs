namespace AirportSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    internal class TravelLinesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.TravelLines.Any())
            {
                return;
            }

            var travelLines = new List<TravelLine>();

            using (StreamReader r = File.OpenText(@"C:\Users\User\Desktop\Airport System WebProject\Data\AirportSystem.Data\JsonDb\TravelLines.json"))
            {
                string json = r.ReadToEnd();
                travelLines = JsonConvert.DeserializeObject<List<TravelLine>>(json);
            }

            await dbContext.TravelLines.AddRangeAsync(travelLines);

            await dbContext.SaveChangesAsync();
        }
    }
}
