using AutoMapper;
using PropertyManagement.DAL.Repositories.Interfaces;
using PropertyManagement.DAL.Entities;
using PropertyManagement.BLL.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PropertyManagement.BLL.Dtos.Property;
using System;
using PropertyManagement.BLL.Validation.Property;

namespace PropertyManagement.BLL.Services.Implementations
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


        public async Task<IEnumerable<PropertyReadDto>> QueryAsync(PropertyQueryParameters query)
        {
            var data = await _unitOfWork.Properties.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(query.Keyword))
                data = data.Where(p => p.Title.Contains(query.Keyword, StringComparison.OrdinalIgnoreCase));

            if (query.PropertyTypeId.HasValue)
                data = data.Where(p => p.PropertyTypeId == query.PropertyTypeId);

            if (query.MinPrice.HasValue)
                data = data.Where(p => p.Price >= query.MinPrice.Value);

            if (query.MaxPrice.HasValue)
                data = data.Where(p => p.Price <= query.MaxPrice.Value);

            data = query.SortBy?.ToLower() switch
            {
                "title" => query.SortDescending ? data.OrderByDescending(p => p.Title) : data.OrderBy(p => p.Title),
                _ => query.SortDescending ? data.OrderByDescending(p => p.Price) : data.OrderBy(p => p.Price)
            };

            data = data.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);

            return _mapper.Map<IEnumerable<PropertyReadDto>>(data);
        }

    }
}
