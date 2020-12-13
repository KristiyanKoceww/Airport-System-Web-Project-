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

    internal class AvioCompanySeeder : ISeeder
    {

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.AvioCompanies.Any())
            {
                return;
            }

            var avioCompanies = new List<AvioCompany>();

            using (StreamReader r = File.OpenText(@"C:\Users\User\Desktop\Airport System WebProject\Data\AirportSystem.Data\JsonDb\AvioCompanies.json"))
            {
                string json = r.ReadToEnd();
                avioCompanies = JsonConvert.DeserializeObject<List<AvioCompany>>(json);
            }

            await dbContext.AvioCompanies.AddRangeAsync(avioCompanies);

            await dbContext.SaveChangesAsync();
        }
    }
}
