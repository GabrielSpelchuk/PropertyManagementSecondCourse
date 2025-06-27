using PropertyManagement.Dtos.User;
using PropertyManagement.Validation.User;

namespace PropertyManagement.Services.Interfaces
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
