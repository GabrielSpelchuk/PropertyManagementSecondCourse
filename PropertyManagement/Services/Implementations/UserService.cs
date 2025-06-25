using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using PropertyManagement.Data.Repositories.Interfaces;
using PropertyManagement.Dtos.User;
using PropertyManagement.Entities;
using PropertyManagement.Services.Interfaces;

namespace PropertyManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepo = unitOfWork.GetRepository<User>();
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public async Task<UserReadDto?> GetByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return null;

            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<UserReadDto> CreateAsync(UserCreateDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _userRepo.AddAsync(user);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<bool> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return false;

            _mapper.Map(dto, user);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync (int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return false;

            _userRepo.Remove(user);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
