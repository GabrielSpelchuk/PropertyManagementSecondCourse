using AutoMapper;
using PropertyManagement.Data.Repositories.Interfaces;
using PropertyManagement.Dtos.Property;
using PropertyManagement.Entities;
using PropertyManagement.Services.Interfaces;

namespace PropertyManagement.Services.Implementations
{
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyReadDto>> GetAllAsync()
        {
            var properties = await _unitOfWork.Properties.GetAllAsync();
            return _mapper.Map<IEnumerable<PropertyReadDto>>(properties);
        }

        public async Task<PropertyReadDto?> GetByIdAsync(int id)
        {
            var property = await _unitOfWork.Properties.GetByIdAsync(id);
            if (property == null) return null;

            return _mapper.Map<PropertyReadDto>(property);
        }

        public async Task<PropertyReadDto> CreateAsync(PropertyCreateDto dto)
        {
            var property = _mapper.Map<Property>(dto);
            property.CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);

            await _unitOfWork.Properties.AddAsync(property);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<PropertyReadDto>(property);
        }

        public async Task<bool> UpdateAsync(int id, PropertyUpdateDto dto)
        {
            var property = await _unitOfWork.Properties.GetByIdAsync(id);
            if (property == null) return false;

            _mapper.Map(dto, property);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var property = await _unitOfWork.Properties.GetByIdAsync(id);
            if (property == null) return false;

            _unitOfWork.Properties.Remove(property);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
