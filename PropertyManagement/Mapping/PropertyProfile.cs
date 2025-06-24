using AutoMapper;
using PropertyManagement.Dtos;
using PropertyManagement.Entities;

namespace PropertyManagement.Mapping
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
