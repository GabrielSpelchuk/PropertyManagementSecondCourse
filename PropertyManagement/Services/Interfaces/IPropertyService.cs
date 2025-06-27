using PropertyManagement.Dtos.Property;
using PropertyManagement.Validation.Property;

namespace PropertyManagement.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyReadDto>> GetAllAsync();
        Task<PropertyReadDto?> GetByIdAsync(int id);
        Task<PropertyReadDto> CreateAsync(PropertyCreateDto dto);
        Task<bool> UpdateAsync(int id, PropertyUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PropertyReadDto>> QueryAsync(PropertyQueryParameters query);
    }
}
