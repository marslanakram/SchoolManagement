using SchoolManagement.Data.Entities;
using SchoolManagement.Data;
using SchoolManagement.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Repository.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly SchoolDbContext _context;

        public UserRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByUserIdAsync(string firstName)
        {
            return await _context.Users
                .FirstOrDefaultAsync(s => s.FirstName == firstName);
        }
    }
}