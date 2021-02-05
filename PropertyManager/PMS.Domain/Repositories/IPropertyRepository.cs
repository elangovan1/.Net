using PMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PMS.Domain.Repositories
{
    public interface IPropertyRepository : IDisposable
    {
        Task<IEnumerable<PropertyTypeModel>> GetAllAsync(CancellationToken ct = default);
        Task<PropertyTypeModel> GetByIdAsync(int id, CancellationToken ct = default);
        Task<PropertyTypeModel> AddAsync(PropertyTypeModel propertyType, CancellationToken ct = default);
        Task<bool> UpdateAsync(PropertyTypeModel propertyType, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
