using NUnit.Framework;
using PMS.DataEFCore.Repositories;
using PMS.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.DataEFCore.Test.Repositories
{
    [TestFixture]
    public class PropertyTypeRepositoryTests : TestBase
    {  

        [Test]
        public async Task AddAsync()
        {
            var repo = new PropertyTypeRepository(dbContext);
            var result = repo.AddAsync(new PropertyTypeModel { Id = 1, Name = "Free" });

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Result.Id, 1);
            Assert.AreEqual(result.Result.Name, "Free");
        }
        [Test]
        public async Task DeleteAsync()
        {
            dbContext.PropertyTypeModel.Add(new PropertyTypeModel { Id = 1, Name = "Free" });
            dbContext.PropertyTypeModel.Add(new PropertyTypeModel { Id = 2, Name = "Lease" });
            dbContext.SaveChanges();

            var repo = new PropertyTypeRepository(dbContext);
            var result = repo.DeleteAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(dbContext.PropertyTypeModel.Count(), 1);
            Assert.AreEqual(dbContext.PropertyTypeModel.First(m => m.Id == 2).Id, 2);
            Assert.AreEqual(dbContext.PropertyTypeModel.First(m => m.Id == 2).Name, "Lease");
        }
        [Test]
        public async Task GetAllAsync()
        {
            dbContext.PropertyTypeModel.Add(new PropertyTypeModel { Id = 1, Name = "Free" });
            dbContext.PropertyTypeModel.Add(new PropertyTypeModel { Id = 2, Name = "Lease" });
            dbContext.SaveChanges();

            var repo = new PropertyTypeRepository(dbContext);            
            var result = repo.GetAllAsync().Result.ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[0].Name, "Free");
            Assert.AreEqual(result[1].Id, 2);
            Assert.AreEqual(result[1].Name, "Lease");
        }
        [Test]
        public async Task GetByIdAsync()
        {
            dbContext.PropertyTypeModel.Add(new PropertyTypeModel { Id = 1, Name = "Free" });
            dbContext.PropertyTypeModel.Add(new PropertyTypeModel { Id = 2, Name = "Lease" });
            dbContext.SaveChanges();
            
            var repo = new PropertyTypeRepository(dbContext);
            var result = repo.GetByIdAsync(1);

            Assert.IsNotNull(result);            
            Assert.AreEqual(result.Result.Id, 1);
            Assert.AreEqual(result.Result.Name, "Free");
            
        }
        [Test]
        public async Task UpdateAsync()
        {
            dbContext.PropertyTypeModel.Add(new PropertyTypeModel { Id = 1, Name = "Free" });
            dbContext.PropertyTypeModel.Add(new PropertyTypeModel { Id = 2, Name = "Lease" });
            dbContext.SaveChanges();
                         
            var repo = new PropertyTypeRepository(dbContext);
            var toUpdate = dbContext.PropertyTypeModel.First(m=>m.Id == 1);
            toUpdate.Name = "Freehold";
            var result = repo.UpdateAsync(toUpdate);

            Assert.IsNotNull(result);
            Assert.AreEqual(dbContext.PropertyTypeModel.First(m=>m.Id == 1).Id, 1);
            Assert.AreEqual(dbContext.PropertyTypeModel.First(m => m.Id == 1).Name, "Freehold"); 
        }
    }
}
