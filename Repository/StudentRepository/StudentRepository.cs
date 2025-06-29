using SchoolManagement.Data.Entities;
using SchoolManagement.Data;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Repository.GenericRepository;

namespace SchoolManagement.Repository.StudentRepository.StudentRepository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Student> GetByStudentIdAsync(string studentId)
        {
            return await _context.Students
                .FirstOrDefaultAsync(s => s.RollNumber == studentId);
        }
    }
}