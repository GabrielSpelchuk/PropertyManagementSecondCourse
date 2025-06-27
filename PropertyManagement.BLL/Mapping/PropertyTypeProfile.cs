using AutoMapper;
using PropertyManagement.BLL.Dtos.PropertyType;
using PropertyManagement.DAL.Entities;

namespace PropertyManagement.BLL.Mapping
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
