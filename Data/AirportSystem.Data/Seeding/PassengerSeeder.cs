namespace AirportSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    internal class PassengerSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Passengers.Any())
            {
                return;
            }

            var passengers = new List<Passenger>();

            for (int i = 1; i <= 20; i++)
            {
                dbContext.Passports.Add(new Passport
                {
                    Id = i.ToString(),
                    Country = "Bulgaria",
                    Nationality = "Bulgarian",
                    CreatedOn = DateTime.Now.AddYears(-5),
                    ExpiresOn = DateTime.Now.AddYears(10),
                });
            }

            using (StreamReader r = File.OpenText(@"C:\Users\User\Desktop\Airport System WebProject\Data\AirportSystem.Data\JsonDb\Passengeers.json"))
            {
                string json = r.ReadToEnd();
                passengers = JsonConvert.DeserializeObject<List<Passenger>>(json);
            }

            await dbContext.AddRangeAsync(passengers);

            await dbContext.SaveChangesAsync();
        }
    }
}
