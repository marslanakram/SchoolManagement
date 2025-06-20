using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Service.UserService
{
    public interface IUserService
    {
        Task<User?> ValidateUserAsync(string email, string password);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(UserDto dto);
        Task<UserDto> UpdateAsync(int id, UserDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
