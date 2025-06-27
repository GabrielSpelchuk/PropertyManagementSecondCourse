using PropertyManagement.Dtos.PropertyType;
using PropertyManagement.Validation.PropertyType;

namespace PropertyManagement.Services.Interfaces
{
    public interface IPropertyTypeService
    {
        Task<IEnumerable<PropertyTypeReadDto>> GetAllAsync();
        Task<PropertyTypeReadDto?> GetByIdAsync(int id);
        Task<PropertyTypeReadDto> CreateAsync(PropertyTypeCreateDto dto);
        Task<bool> UpdateAsync(int id, PropertyTypeUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PropertyTypeReadDto>> QueryAsync(PropertyTypeQueryParameters query);
    }
}
