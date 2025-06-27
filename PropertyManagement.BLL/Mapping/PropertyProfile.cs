using AutoMapper;
using PropertyManagement.DAL.Entities;
using PropertyManagement.BLL.Dtos.Property;

namespace PropertyManagement.BLL.Mapping
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, PropertyReadDto>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.FullName))
                .ForMember(dest => dest.PropertyTypeName, opt => opt.MapFrom(src => src.PropertyType.Name));

            CreateMap<PropertyCreateDto, Property>();
            CreateMap<PropertyUpdateDto, Property>();
        }
    }
}
