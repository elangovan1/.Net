using Microsoft.EntityFrameworkCore;
using PMS.Domain.Entities;

namespace PMS.DataEFCore.DBContext
{
    public class DatabaseContext : DbContext, IDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<PropertyTypeModel> PropertyTypeModel { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyTypeModel>().ToTable("PropertyType");          
        }
    }
}
