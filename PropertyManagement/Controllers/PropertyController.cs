using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Data.Repositories.Interfaces;
using PropertyManagement.Enteties;

namespace PropertyManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var properties = await _unitOfWork.Properties.GetAllAsync();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var properties = await _unitOfWork.Properties.GetByIdAsync(id);
            if (properties == null) return NotFound();
            return Ok(properties);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Property property)
        {
            await _unitOfWork.Properties.AddAsync(property);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = property.Id }, property);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Property updated)
        {
            var property = await _unitOfWork.Properties.GetByIdAsync(id);
            if (property == null) return NotFound();

            property.Title = updated.Title;
            property.Description = updated.Description;
            property.Price = updated.Price;
            property.Address = updated.Address;

            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var property = await _unitOfWork.Properties.GetByIdAsync(id);
            if (property == null) return NotFound();

            _unitOfWork.Properties.Remove(property);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
