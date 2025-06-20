using AutoMapper;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.UserRepository;
using System.Security.Cryptography;
using System.Text;

namespace SchoolManagement.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateAsync(UserDto dto)
        {
            var entity = _mapper.Map<User>(dto);

            // ✅ Hash the password and store it
            entity.PasswordHash = HashPassword(dto.Password);

            await _userRepository.AddAsync(entity);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> UpdateAsync(int id, UserDto dto)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);

            // ✅ Update PasswordHash only if new password is provided
            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                existing.PasswordHash = HashPassword(dto.Password);
            }

            _userRepository.Update(existing);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _userRepository.Delete(entity);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        // ✅ Helper method to hash passwords using SHA256
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
