using SchoolManagement.Data.Entities;
using SchoolManagement.Data;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Repository.GenericRepository;

namespace SchoolManagement.Repository.TeacherRepository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly SchoolDbContext _context;

        public TeacherRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Teacher> GetByTeacherIdAsync(string teacherId)
        {
            return await _context.Teachers
                .FirstOrDefaultAsync(s => s.TeacherId == teacherId);
        }
    }
}