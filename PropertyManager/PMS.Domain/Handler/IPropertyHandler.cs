using PMS.Domain.APIEntities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PMS.Domain.Handler
{
    public interface IPropertyHandler : IDisposable
    {
        Task<IEnumerable<PropertyType>> GetAllAsync(CancellationToken ct = default);
        Task<PropertyType> GetByIdAsync(int id, CancellationToken ct = default);
        Task<PropertyType> AddAsync(PropertyType propertyType, CancellationToken ct = default);
        Task<bool> UpdateAsync(PropertyType propertyType, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
