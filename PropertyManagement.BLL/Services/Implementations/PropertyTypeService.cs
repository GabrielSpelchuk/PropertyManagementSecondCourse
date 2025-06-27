using AutoMapper;
using PropertyManagement.DAL.Repositories.Interfaces;
using PropertyManagement.DAL.Entities;
using PropertyManagement.BLL.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PropertyManagement.BLL.Dtos.PropertyType;
using PropertyManagement.BLL.Validation.PropertyType;

namespace PropertyManagement.BLL.Services.Implementations
{
    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly IGenericRepository<PropertyType> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork.GetRepository<PropertyType>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyTypeReadDto>> GetAllAsync()
        {
            var types = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<PropertyTypeReadDto>>(types);
        }

        public async Task<PropertyTypeReadDto?> GetByIdAsync(int id)
        {
            var type = await _repo.GetByIdAsync(id);
            if (type == null) return null;

            return _mapper.Map<PropertyTypeReadDto>(type);
        }

        public async Task<PropertyTypeReadDto> CreateAsync(PropertyTypeCreateDto dto)
        {
            var type = _mapper.Map<PropertyType>(dto);
            await _repo.AddAsync(type);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PropertyTypeReadDto>(type);
        }

        public async Task<bool> UpdateAsync(int id, PropertyTypeUpdateDto dto)
        {
            var type = await _repo.GetByIdAsync(id);
            if (type == null) return false;

            _mapper.Map(dto, type);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var type = await _repo.GetByIdAsync(id);
            if (type == null) return false;

            _repo.Remove(type);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<PropertyTypeReadDto>> QueryAsync(PropertyTypeQueryParameters query)
        {
            var data = await _repo.GetAllAsync();

            data = data.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);

            return _mapper.Map<IEnumerable<PropertyTypeReadDto>>(data);
        }

    }
}
