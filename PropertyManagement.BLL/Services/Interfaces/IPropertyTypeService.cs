using PropertyManagement.BLL.Dtos.PropertyType;
using PropertyManagement.BLL.Validation.PropertyType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyManagement.BLL.Services.Interfaces
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
