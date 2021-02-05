using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PMS.Domain.APIEntities;
using PMS.Domain.Handler;

namespace PMS.API.Controllers
{
    [Route("api/type")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class PropertyTypeController : ControllerBase
    {
        private readonly IPropertyHandler _propertyHandler;

        public PropertyTypeController(IPropertyHandler propertyHandler)
        {
            _propertyHandler = propertyHandler;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<PropertyType>))]
        public async Task<ActionResult<IEnumerable<PropertyType>>> GetAllAsync()
        {
            try
            {
                var result = await _propertyHandler.GetAllAsync();
                if (!result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(PropertyType))]
        public async Task<ActionResult<PropertyType>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _propertyHandler.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
                
        [HttpPost]
        public async Task<ActionResult<PropertyType>> Post([FromBody] PropertyType input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return new OkObjectResult(await _propertyHandler.AddAsync(input)) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PropertyType>> Put(int id, [FromBody] PropertyType input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                var result = await _propertyHandler.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return StatusCode(201, await _propertyHandler.UpdateAsync(input));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _propertyHandler.DeleteAsync(id);
                if (!result)
                {
                    return StatusCode(500);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}