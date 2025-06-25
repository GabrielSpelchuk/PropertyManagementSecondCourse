using AutoMapper;
using PropertyManagement.Dtos.PropertyType;
using PropertyManagement.Entities;

namespace PropertyManagement.Mapping
{
    public class PropertyTypeProfile : Profile
    {
        public PropertyTypeProfile()
        {
            CreateMap<PropertyType, PropertyTypeReadDto>();
            CreateMap<PropertyTypeCreateDto, PropertyType>();
            CreateMap<PropertyTypeUpdateDto, PropertyType>();
        }
    }
}
