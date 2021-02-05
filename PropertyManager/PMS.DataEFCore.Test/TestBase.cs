using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PMS.DataEFCore.DBContext;

namespace PMS.DataEFCore.Test
{
    public class TestBase 
    {
        internal DatabaseContext dbContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                           .UseInMemoryDatabase(databaseName: "PMS Test")
                           .Options;
            dbContext = new DatabaseContext(options);
        }

        [TearDown]
        public void Clear()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
