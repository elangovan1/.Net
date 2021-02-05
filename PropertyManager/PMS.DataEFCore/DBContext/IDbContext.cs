using Microsoft.EntityFrameworkCore;
using PMS.Domain.Entities;

namespace PMS.DataEFCore.DBContext
{
    public interface IDbContext
    {
         DbSet<PropertyTypeModel> PropertyTypeModel { get; set; }
    }
}
