namespace AirportSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data.Models.Destinations;
    using Newtonsoft.Json;

    internal class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            var cities = new List<City>();

            using (StreamReader r = File.OpenText(@"C:\Users\User\Desktop\Airport System WebProject\Data\AirportSystem.Data\JsonDb\Cities.json"))
            {
                string json = r.ReadToEnd();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            for (int i = 0; i < cities.Count; i++)
            {
                var name = cities[i].Name;

                if (!dbContext.Cities.Any(x => x.Name.ToLower() == cities[i].Name.ToLower()))
                {
                    dbContext.Cities.Add(cities[i]);
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
