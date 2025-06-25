using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Dtos.PropertyType;
using PropertyManagement.Services.Interfaces;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var type = await _typeService.GetByIdAsync(id);
            if (type == null) return NotFound();

            return Ok(type);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropertyTypeCreateDto dto)
        {
            var created = await _typeService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new {id = created.Id}, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PropertyTypeUpdateDto dto)
        {
            var type = await _typeService.UpdateAsync(id, dto);
            if (!type) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var type = await _typeService.DeleteAsync(id);
            if (!type) return NotFound();

            return NoContent();
        }
    }
}
