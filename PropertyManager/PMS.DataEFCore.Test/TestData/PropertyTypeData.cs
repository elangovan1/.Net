using PMS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PMS.DataEFCore.Test.TestData
{
    public static class PropertyTypeData
    {
        public static PropertyTypeModel PropertyTypeModel
        {
            get
            {
                return new PropertyTypeModel { Id = 1, Name = "Freehold" };
            }
        }

        public static IQueryable<PropertyTypeModel> PropertyTypeModels
        {
            get
            {
                return new List<PropertyTypeModel>
                {
                    new PropertyTypeModel { Id = 1, Name = "Freehold" },
                    new PropertyTypeModel { Id = 2, Name = "Leasehold" }
                }
                .AsQueryable();
            }
        }
    }
}
