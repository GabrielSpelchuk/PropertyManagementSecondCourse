using Microsoft.AspNetCore.Mvc;
using PropertyManagement.BLL.Dtos.PropertyType;
using PropertyManagement.BLL.Exceptions;
using PropertyManagement.BLL.Services.Interfaces;
using PropertyManagement.BLL.Validation.PropertyType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyTypeController : ControllerBase
    {
        private readonly IPropertyTypeService _typeService;

        public PropertyTypeController (IPropertyTypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _typeService.GetAllAsync());
        }

        /// <summary>
        /// Get a property type by ID
        /// </summary>
        /// <param name="id">Property type ID</param>
        /// <returns>Property type details</returns>
        /// <response code="200">Return the property type</response>
        /// <response code="404">If the property type is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PropertyTypeReadDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            var type = await _typeService.GetByIdAsync(id);
            if (type == null)
                throw new NotFoundException($"Property type with ID {id} not found");

            return Ok(type);
        }

        /// <summary>
        /// Create a new property type
        /// </summary>
        /// <param name="dto">New property type data</param>
        /// <returns>Created property type</returns>
        /// <response code="201">Property type created successfylly</response>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(typeof(PropertyTypeReadDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] PropertyTypeCreateDto dto)
        {
            if (!ModelState.IsValid)
                throw new BadRequestException("Invalid property type data");

            var created = await _typeService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new {id = created.Id}, created);
        }

        /// <summary>
        /// Update a property type
        /// </summary>
        /// <param name="id">ID of the property type to update</param>
        /// <param name="dto">Updated data</param>
        /// <returns>No content</returns>
        /// <response code="204">Updated successful</response>
        /// <response code="404">Property type not found</response>
        /// <response code="400">Invalid input</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] PropertyTypeUpdateDto dto)
        {
            if (!ModelState.IsValid)
                throw new BadRequestException("Invalid property type update data");

            var type = await _typeService.UpdateAsync(id, dto);
            if (!type)
                throw new NotFoundException($"Property type with ID {id} not found");

            return NoContent();
        }

        /// <summary>
        /// Delete a property type
        /// </summary>
        /// <param name="id">Id of the property type</param>
        /// <returns>No content</returns>
        /// <response code="204">Delete successful</response>
        /// <response code="404">Property type not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var type = await _typeService.DeleteAsync(id);
            if (!type)
                throw new NotFoundException($"Property type with ID {id} not found");

            return NoContent();
        }

        /// <summary>
        /// Get paginated property type
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Paginated property types</returns>
        /// <response code="204">Paginated successful</response>
        /// <response code="400">Invalid input</response>
        [HttpGet("query")]
        [ProducesResponseType(typeof(IEnumerable<PropertyTypeReadDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Query([FromQuery] PropertyTypeQueryParameters query)
        {
            var validator = new PropertyTypeQueryValidator();
            var result = validator.Validate(query);

            if (!result.IsValid)
                throw new BadRequestException("Invalid query parameters");

            var data = await _typeService.QueryAsync(query);
            return Ok(data);
        }
    }
}
