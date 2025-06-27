using PropertyManagement.BLL.Dtos.User;
using PropertyManagement.BLL.Validation.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyManagement.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto?> GetByIdAsync(int id);
        Task<UserReadDto> CreateAsync(UserCreateDto dto);
        Task<bool> UpdateAsync( int id, UserUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<UserReadDto>> QueryAsync(UserQueryParameters query);
    }
}
