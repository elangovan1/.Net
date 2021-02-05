using Microsoft.EntityFrameworkCore;
using PMS.DataEFCore.DBContext;
using PMS.Domain.Entities;
using PMS.Domain.Repositories;
using PMS.Utility.Validation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PMS.DataEFCore.Repositories
{
    public class PropertyTypeRepository : IPropertyRepository
    {
        private readonly DatabaseContext _context;
       
        public PropertyTypeRepository(DatabaseContext dbContext)
        {
            Ensure.IsNotNull(dbContext, nameof(dbContext));
            _context = dbContext;
        }
        public async Task<PropertyTypeModel> AddAsync(PropertyTypeModel propertyType, CancellationToken ct = default)
        {
            Ensure.IsNotNull(propertyType, nameof(propertyType));
            _context.PropertyTypeModel.Add(propertyType);
            await _context.SaveChangesAsync(ct);
            return propertyType;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var result = false;
            var toRemove = _context.PropertyTypeModel.Find(id);
            if (toRemove !=null)
            {             
                _context.PropertyTypeModel.Remove(toRemove);
                await _context.SaveChangesAsync(ct);
                result = true;
            }
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<PropertyTypeModel>> GetAllAsync(CancellationToken ct = default)
        {
           var result = await _context.PropertyTypeModel.AsNoTracking().ToListAsync(ct);
           return result;
        }

        public async Task<PropertyTypeModel> GetByIdAsync(int id, CancellationToken ct = default)
        {            
            return await _context.PropertyTypeModel.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(PropertyTypeModel input, CancellationToken ct = default)
        {
            var result = false;
            Ensure.IsNotNull(input, nameof(input));
            if (await IsPropertyTypExists(input.Id))
            {
                _context.PropertyTypeModel.Update(input);
                await _context.SaveChangesAsync(ct);
                result = true;
            }            
            return result;
        }
        private async Task<bool> IsPropertyTypExists(int id, CancellationToken ct = default) => await _context.PropertyTypeModel.AnyAsync(a => a.Id == id, ct);
    }
}
