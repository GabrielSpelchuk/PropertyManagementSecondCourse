using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Data.Repositories.Interfaces;
using PropertyManagement.Entities;
using PropertyManagement.Services.Interfaces;
using PropertyManagement.Dtos.Property;


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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var properties = await _propertyService.GetByIdAsync(id);
            if (properties == null) return NotFound();
            return Ok(properties);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropertyCreateDto dto)
        {
            var created = await _propertyService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PropertyUpdateDto dto)
        {
            var property = await _propertyService.UpdateAsync(id, dto);
            if (!property) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var property = await _propertyService.DeleteAsync(id);
            if (!property) return NotFound();

            return NoContent();
        }
    }
}
