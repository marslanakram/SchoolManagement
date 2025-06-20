//using AutoMapper;
//using Microsoft.EntityFrameworkCore;
//using SchoolManagement.Data;
//using SchoolManagement.Data.Dto;
//using SchoolManagement.Data.Entities;
//using SchoolManagement.Repository.UserRepository;
//using System.Security.Cryptography;
//using System.Text;

//namespace SchoolManagement.Service.UserService
//{
//    public class UserService : IUserService
//    {
//        private readonly IUserRepository _userRepository;
//        private readonly IMapper _mapper;
//        private readonly SchoolDbContext _context;

//        public UserService(IUserRepository userRepository, IMapper mapper, SchoolDbContext context)
//        {
//            _userRepository = userRepository;
//            _mapper = mapper;
//            _context = context;
//        }

//        public async Task<IEnumerable<UserDto>> GetAllAsync()
//        {
//            var users = await _userRepository.GetAllAsync();
//            return _mapper.Map<IEnumerable<UserDto>>(users);
//        }

//        public async Task<UserDto> GetByIdAsync(int id)
//        {
//            var user = await _userRepository.GetByIdAsync(id);
//            return user == null ? null : _mapper.Map<UserDto>(user);
//        }

//        public async Task<UserDto> CreateAsync(UserDto dto)
//        {
//            var entity = _mapper.Map<User>(dto);

//            // ✅ Hash the password and store it
//            entity.PasswordHash = HashPassword(dto.Password);

//            await _userRepository.AddAsync(entity);
//            await _userRepository.SaveChangesAsync();

//            return _mapper.Map<UserDto>(entity);
//        }

//        public async Task<UserDto> UpdateAsync(int id, UserDto dto)
//        {
//            var existing = await _userRepository.GetByIdAsync(id);
//            if (existing == null) return null;

//            _mapper.Map(dto, existing);

//            // ✅ Update PasswordHash only if new password is provided
//            if (!string.IsNullOrWhiteSpace(dto.Password))
//            {
//                existing.PasswordHash = HashPassword(dto.Password);
//            }

//            _userRepository.Update(existing);
//            await _userRepository.SaveChangesAsync();

//            return _mapper.Map<UserDto>(existing);
//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            var entity = await _userRepository.GetByIdAsync(id);
//            if (entity == null) return false;

//            _userRepository.Delete(entity);
//            await _userRepository.SaveChangesAsync();
//            return true;
//        }

//        // ✅ Helper method to hash passwords using SHA256
//        private string HashPassword(string password)
//        {
//            using var sha = SHA256.Create();
//            var bytes = Encoding.UTF8.GetBytes(password);
//            var hash = sha.ComputeHash(bytes);
//            return Convert.ToBase64String(hash);
//        }

//        public async Task<User?> ValidateUserAsync(string email, string password)
//        {
//            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
//            if (user == null) return null;

//            var hash = ComputeHash(password);
//            return user.PasswordHash == hash ? user : null;
//        }

//        private string ComputeHash(string input)
//        {
//            using var sha256 = SHA256.Create();
//            var bytes = Encoding.UTF8.GetBytes(input);
//            var hash = sha256.ComputeHash(bytes);
//            return Convert.ToBase64String(hash);
//        }
//    }
//}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
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
        private readonly SchoolDbContext _context;

        public UserService(IUserRepository userRepository, IMapper mapper, SchoolDbContext context)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
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
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                throw new ArgumentException("Email already exists");
            }

            var entity = _mapper.Map<User>(dto);
            entity.PasswordHash = HashPassword(dto.Password);

            await _userRepository.AddAsync(entity);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> UpdateAsync(int id, UserDto dto)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null) return null;

            if (await _context.Users.AnyAsync(u => u.Email == dto.Email && u.Id != id))
            {
                throw new ArgumentException("Email already in use by another user");
            }

            _mapper.Map(dto, existing);

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

        public async Task<User?> ValidateUserAsync(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) return null;

            return VerifyPassword(password, user.PasswordHash) ? user : null;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            var computedHash = HashPassword(inputPassword);
            return computedHash.Equals(storedHash);
        }
    }
}