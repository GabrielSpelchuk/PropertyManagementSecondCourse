using AutoMapper;
using PropertyManagement.DAL.Entities;
using PropertyManagement.BLL.Dtos.User;

namespace PropertyManagement.BLL.Mapping
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
