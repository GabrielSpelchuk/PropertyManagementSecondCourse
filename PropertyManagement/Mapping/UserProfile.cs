using AutoMapper;
using PropertyManagement.Dtos.User;
using PropertyManagement.Entities;

namespace PropertyManagement.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
