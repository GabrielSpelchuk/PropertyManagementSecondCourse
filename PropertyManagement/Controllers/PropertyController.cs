using Microsoft.AspNetCore.Mvc;
using PropertyManagement.BLL.Services.Interfaces;
using System.Threading.Tasks;
using PropertyManagement.BLL.Dtos.Property;
using System.Collections.Generic;
using PropertyManagement.BLL.Validation.Property;
using PropertyManagement.BLL.Exceptions;


namespace PropertyManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService unitOfWork)
        {
            _propertyService = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var properties = await _propertyService.GetAllAsync();
            return Ok(properties);
        }

        /// <summary>
        /// Get a property by ID
        /// </summary>
        /// <param name="id">Property ID</param>
        /// <returns>Property details</returns>
        /// <response code="200">Return the property</response>
        /// <response code="404">If the property is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PropertyReadDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            var properties = await _propertyService.GetByIdAsync(id);
            if (properties == null)
                throw new NotFoundException($"Property with ID {id} not found");

            return Ok(properties);
        }

        /// <summary>
        /// Create a new property
        /// </summary>
        /// <param name="dto">New property data</param>
        /// <returns>Created property</returns>
        /// <response code="201">Property created successfylly</response>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(typeof(PropertyReadDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] PropertyCreateDto dto)
        {
            if (!ModelState.IsValid)
                throw new BadRequestException("Invalid property data");

            var created = await _propertyService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// Update a property
        /// </summary>
        /// <param name="id">ID of the property to update</param>
        /// <param name="dto">Updated data</param>
        /// <returns>No content</returns>
        /// <response code="204">Updated successful</response>
        /// <response code="404">Property not found</response>
        /// <response code="400">Invalid input</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] PropertyUpdateDto dto)
        {
            if (!ModelState.IsValid)
                throw new BadRequestException("Invalid property update data");

            var property = await _propertyService.UpdateAsync(id, dto);
            if (!property)
                throw new NotFoundException($"Property with ID {id} not found");

            return NoContent();
        }

        /// <summary>
        /// Delete a property
        /// </summary>
        /// <param name="id">Id of the property</param>
        /// <returns>No content</returns>
        /// <response code="204">Delete successful</response>
        /// <response code="404">Property not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var property = await _propertyService.DeleteAsync(id);
            if (!property)
                throw new NotFoundException($"Property with ID {id} not found");

            return NoContent();
        }

        /// <summary>
        /// Get filtered, sorted and paginated properties
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Filtered, sorted, paginated properties</returns>
        /// <response code="200">Filtered, sorted, paginated successful</response>
        /// <response code="400">Invalid input</response>
        [HttpGet("query")]
        [ProducesResponseType(typeof(IEnumerable<PropertyReadDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Query([FromQuery] PropertyQueryParameters query)
        {
            var validator = new PropertyQueryValidator();
            var result = validator.Validate(query);

            if (!result.IsValid)
                throw new BadRequestException("Invalid query parameters");

            var data = await _propertyService.QueryAsync(query);
            return Ok(data);
        }
    }
}
