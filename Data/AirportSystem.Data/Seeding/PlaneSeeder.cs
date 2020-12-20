namespace AirportSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AirportSystem.Data.Planes;
    using Newtonsoft.Json;

    internal class PlaneSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Planes.Any())
            {
                return;
            }

            var planes = new List<Plane>();

            using (StreamReader r = File.OpenText(@"C:\Users\User\Desktop\Airport System WebProject\Data\AirportSystem.Data\JsonDb\Planes.json"))
            {
                string json = r.ReadToEnd();
                planes = JsonConvert.DeserializeObject<List<Plane>>(json);
            }

            await dbContext.Planes.AddRangeAsync(planes);

            await dbContext.SaveChangesAsync();
        }
    }
}
