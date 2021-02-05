using PMS.DataEFCore.Extension;
using PMS.Domain.APIEntities;
using PMS.Domain.Handler;
using PMS.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PMS.DataEFCore.Handler
{
    public class PropertyTypeHandler : IPropertyHandler
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyTypeHandler(IPropertyRepository propertyTypeModel)
        {
            _propertyRepository = propertyTypeModel;
        }

        public async Task<PropertyType> AddAsync(PropertyType propertyType, CancellationToken ct = default)
        {
            var propertyTypeModel = propertyType.Convert();
            var result = await _propertyRepository.AddAsync(propertyTypeModel, ct);
            return result.Convert();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        { 
            return await _propertyRepository.DeleteAsync(id, ct);            
        }

        public void Dispose()
        {            
        }

        public async Task<IEnumerable<PropertyType>> GetAllAsync(CancellationToken ct = default)
        {            
            var result = await _propertyRepository.GetAllAsync(ct);
            return result.ConvertAll();
        }

        public async Task<PropertyType> GetByIdAsync(int id, CancellationToken ct = default)
        { 
            var result = await _propertyRepository.GetByIdAsync(id, ct);
            return result.Convert();
        }

        public async Task<bool> UpdateAsync(PropertyType propertyType, CancellationToken ct = default)
        {
            var propertyTypeModel = propertyType.Convert();
            return await _propertyRepository.UpdateAsync(propertyTypeModel, ct);            
        }
    }
}
