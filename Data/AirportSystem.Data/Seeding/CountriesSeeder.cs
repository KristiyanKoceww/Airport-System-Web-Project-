namespace AirportSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data.Models.Destinations;
    using Newtonsoft.Json;

    internal class CountriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Countries.Any())
            {
                return;
            }

            var countries = new List<Country>();

            using (StreamReader r = File.OpenText(@"C:\Users\User\Desktop\Airport System WebProject\Data\AirportSystem.Data\JsonDb\Countries.json"))
            {
                string json = r.ReadToEnd();
                countries = JsonConvert.DeserializeObject<List<Country>>(json);
            }

            for (int i = 0; i < countries.Count; i++)
            {
                var name = countries[i].Name;

                if (!dbContext.Countries.Any(x => x.Name.ToLower() == countries[i].Name.ToLower()))
                {
                    dbContext.Countries.Add(countries[i]);
                }
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
