namespace AirportSystem.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AirportSystem.Data;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseServiceTests : IDisposable
    {
        public BaseServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;
            this.DbContext = new ApplicationDbContext(options);
        }

        protected ApplicationDbContext DbContext { get; set; }

        public void Dispose()
        {
            this.DbContext.Database.EnsureDeleted();
            this.DbContext.Dispose();
        }
    }
}
