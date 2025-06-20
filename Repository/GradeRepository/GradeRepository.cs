using SchoolManagement.Data.Entities;
using SchoolManagement.Data;
using SchoolManagement.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Repository.GradeRepository
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        private readonly SchoolDbContext _context;

        public GradeRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Grade> GetByGradeIdAsync(int studentId)
        {
            return await _context.Grades
                .FirstOrDefaultAsync(s => s.StudentId == studentId);
        }
    }
}