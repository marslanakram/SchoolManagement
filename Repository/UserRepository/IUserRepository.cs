using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.GenericRepository;

namespace SchoolManagement.Repository.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUserIdAsync(string userId);
    }
}