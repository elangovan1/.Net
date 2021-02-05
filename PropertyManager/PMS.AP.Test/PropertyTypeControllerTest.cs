using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PMS.API.Controllers;
using PMS.Domain.APIEntities;
using PMS.Domain.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace PMS.API.Test
{
    public class PropertyTypeControllerTest 
    {
        private readonly Mock<IPropertyHandler> _propertyHandler;
        private readonly PropertyTypeController _controller;

        public PropertyTypeControllerTest()
        {
            _propertyHandler = new Mock<IPropertyHandler>();
            _controller = new PropertyTypeController(_propertyHandler.Object);
        }

        [Test]
        public async Task PropertyTypeController_GetAllAsync_Returns_ValidResponse()
        {
            IEnumerable<PropertyType> propertyTypes = new List<PropertyType> { new PropertyType { Id = 1, Name = "Free" }, new PropertyType { Id = 2, Name = "Lease" } };            
            _propertyHandler.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(propertyTypes));
            var result = await _controller.GetAllAsync();
                        
            Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
            var status = result.Result as OkObjectResult;
            Assert.AreEqual(200, status.StatusCode); 
            Assert.IsInstanceOf(typeof(IEnumerable<PropertyType>), status.Value);
            Assert.AreEqual((status.Value as IEnumerable<PropertyType>).First().Id, 1);
            Assert.AreEqual((status.Value as IEnumerable<PropertyType>).First().Name, "Free");
            Assert.AreEqual((status.Value as IEnumerable<PropertyType>).Last().Id, 2);
            Assert.AreEqual((status.Value as IEnumerable<PropertyType>).Last().Name, "Lease");
            _propertyHandler.Verify(x => x.GetAllAsync(It.IsAny<CancellationToken>()));
        }
        [Test]
        public async Task PropertyTypeController_GetByIdAsync_Returns_ValidResponse()
        {
            var propertyType =  new PropertyType { Id = 1, Name = "Free" };
            _propertyHandler.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(propertyType));
            var result = await _controller.GetByIdAsync(1);
            Assert.IsInstanceOf(typeof(ActionResult<PropertyType>), result);
            var status = result.Result as OkObjectResult;
            Assert.AreEqual(200, status.StatusCode);
            Assert.IsInstanceOf(typeof(PropertyType), status.Value);
            Assert.AreEqual((status.Value as PropertyType).Id, 1);
            Assert.AreEqual((status.Value as PropertyType).Name, "Free");
            _propertyHandler.Verify(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()));
        }       
        [Test]
        public async Task PropertyTypeController_Post_Returns_ValidResponse()
        {
            var propertyType = new PropertyType { Id = 1, Name = "Free" };
            _propertyHandler.Setup(x => x.AddAsync(It.IsAny<PropertyType>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(propertyType));
            var result = await _controller.Post(propertyType);
            Assert.IsInstanceOf(typeof(ActionResult<PropertyType>), result);
            var status = result.Result as OkObjectResult;
            Assert.AreEqual(201, status.StatusCode);
            Assert.IsInstanceOf(typeof(PropertyType), status.Value);
            Assert.AreEqual((status.Value as PropertyType).Id, 1);
            Assert.AreEqual((status.Value as PropertyType).Name, "Free");
            _propertyHandler.Verify(x => x.AddAsync(It.IsAny<PropertyType>(), It.IsAny<CancellationToken>()));
        }
        [Test]
        public async Task PropertyTypeController_Put_Returns_ValidResponse()
        {
            var propertyType = new PropertyType { Id = 1, Name = "Free" };
            _propertyHandler.Setup(x => x.UpdateAsync(It.IsAny<PropertyType>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(true));
            var result = await _controller.Put(1, propertyType);
            Assert.IsInstanceOf(typeof(ActionResult<PropertyType>), result);
            _propertyHandler.Verify(x => x.UpdateAsync(It.IsAny<PropertyType>(), It.IsAny<CancellationToken>()));
        }
        [Test]
        public async Task PropertyTypeController_DeleteAsync_Returns_TrueWhenDeletedSuccessfully()
        {
            IEnumerable<PropertyType> propertyTypes = new List<PropertyType> { new PropertyType { Id = 1, Name = "Free" }, new PropertyType { Id = 2, Name = "Lease" } };
            _propertyHandler.Setup(x => x.DeleteAsync(It.IsAny<int>(),It.IsAny<CancellationToken>())).Returns(Task.FromResult(true));
            var result = await _controller.DeleteAsync(1);
            Assert.IsInstanceOf(typeof(OkResult), result);
            _propertyHandler.Verify(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()));
        }
        [Test]
        public async Task PropertyTypeController_DeleteAsync_Returns_FalseWhenNotDeletedSuccessfully()
        {
            IEnumerable<PropertyType> propertyTypes = new List<PropertyType> { new PropertyType { Id = 1, Name = "Free" }, new PropertyType { Id = 2, Name = "Lease" } };
            _propertyHandler.Setup(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(false));
            var result = await _controller.DeleteAsync(2);
            Assert.IsInstanceOf(typeof(StatusCodeResult), result);
            var status = result as StatusCodeResult;
            Assert.AreEqual(500, status.StatusCode);
            _propertyHandler.Verify(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()));
        }
        [Test]
        public async Task PropertyTypeController_DeleteAsync_Returns_StatusCode500()
        {
            IEnumerable<PropertyType> propertyTypes = new List<PropertyType> { new PropertyType { Id = 1, Name = "Free" }, new PropertyType { Id = 2, Name = "Lease" } };
            _propertyHandler.Setup(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Throws(new Exception()); ;
            var result = await _controller.DeleteAsync(2);
            Assert.IsInstanceOf(typeof(ObjectResult), result);
            var status = result as ObjectResult;
            Assert.AreEqual(500, status.StatusCode);
            _propertyHandler.Verify(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()));
        }
    }
}
