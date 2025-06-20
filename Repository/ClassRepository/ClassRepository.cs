using SchoolManagement.Data.Entities;
using SchoolManagement.Data;
using SchoolManagement.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Repository.ClassRepository
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        private readonly SchoolDbContext _context;

        public ClassRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Class> GetByClassIdAsync(string name)
        {
            return await _context.Classes
                .FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}