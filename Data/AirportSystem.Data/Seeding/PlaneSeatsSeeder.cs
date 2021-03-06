﻿namespace AirportSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AirportSystem.Data.Models.Planes;

    internal class PlaneSeatsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Seats.Any())
            {
                return;
            }

            var planes = dbContext.Planes.ToList();

            Random random = new Random();

            for (int i = 0; i < planes.Count; i++)
            {
                var count = random.Next(40, 80);
                var number = 1;

                for (int k = 0; k <= count; k++)
                {
                    planes[i].Seats.Add(new Seat
                    {
                        IsAvailable = true,
                        SeatNumber = number,
                    });

                    number++;
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
