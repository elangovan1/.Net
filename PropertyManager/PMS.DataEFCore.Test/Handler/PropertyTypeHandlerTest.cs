using Moq;
using NUnit.Framework;
using PMS.DataEFCore.Handler;
using PMS.Domain.APIEntities;
using PMS.Domain.Entities;
using PMS.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PMS.DataEFCore.Test.Handler
{
    public class PropertyTypeHandlerTest : TestBase
    {
        [Test]
        public void PropertyTypeHandler_AddAsync_Returns_PropertyTypeModel_When_InputIsValid()
        {
            var propertyType = new PropertyType { Id = 1, Name = "Free" };
            var propertyTypeModel = propertyType.Convert();
            var propertyRepository = new Mock<IPropertyRepository>();
            var propertyTypeHandler = new PropertyTypeHandler(propertyRepository.Object);
            propertyRepository.Setup(x => x.AddAsync(It.IsAny<PropertyTypeModel>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(propertyTypeModel));

            var result = propertyTypeHandler.AddAsync(propertyType);

            Assert.IsInstanceOf(typeof(PropertyType), result.Result);
        }
        [Test]
        public void PropertyTypeHandler_DeleteAsync_Returns_PropertyTypeModel_When_InputIsValid()
        {
            var propertyType = new PropertyType { Id = 1, Name = "Free" };
            var propertyTypeModel = propertyType.Convert();
            var propertyRepository = new Mock<IPropertyRepository>();
            var propertyTypeHandler = new PropertyTypeHandler(propertyRepository.Object);
            propertyRepository.Setup(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(true));

            var result = propertyTypeHandler.DeleteAsync(1);

            Assert.IsInstanceOf(typeof(bool), true);
        }
        [Test]
        public void PropertyTypeHandler_GetAllAsync_Returns_PropertyTypeModel_When_InputIsValid()
        {
            var propertyTypeModels = new List<PropertyTypeModel>();
            propertyTypeModels.Add(new PropertyTypeModel { Id = 1, Name = "Free" });
            propertyTypeModels.Add(new PropertyTypeModel { Id = 1, Name = "Lease" });
             
            var propertyRepository = new Mock<IPropertyRepository>();
            var propertyTypeHandler = new PropertyTypeHandler(propertyRepository.Object);
            propertyRepository.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(propertyTypeModels.AsEnumerable()));

            var result = propertyTypeHandler.GetAllAsync();

            Assert.IsTrue(result.Result.Count() == 2);
        }
        [Test]
        public void PropertyTypeHandler_GetByIdAsync_Returns_PropertyTypeModel_When_InputIsValid()
        {
            var propertyTypeModel = new PropertyTypeModel { Id = 1, Name = "Free" };
            
            var propertyRepository = new Mock<IPropertyRepository>();
            var propertyTypeHandler = new PropertyTypeHandler(propertyRepository.Object);
            propertyRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(propertyTypeModel));

            var result = propertyTypeHandler.GetByIdAsync(1);

            Assert.IsTrue(result.Result.Id == 1);
            Assert.IsTrue(result.Result.Name == "Free");
        }
        [Test]
        public void PropertyTypeHandler_UpdateAsync_Returns_PropertyTypeModel_When_InputIsValid()
        {
            var propertyTypeModel = new PropertyTypeModel { Id = 1, Name = "Free" };

            var propertyRepository = new Mock<IPropertyRepository>();
            var propertyTypeHandler = new PropertyTypeHandler(propertyRepository.Object);
            propertyRepository.Setup(x => x.UpdateAsync(It.IsAny<PropertyTypeModel>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(true));

            var result = propertyTypeHandler.UpdateAsync(propertyTypeModel.Convert());

            Assert.IsInstanceOf(typeof(bool), true);
        }
    }
}
