using SchoolManagement.Data.Entities;
using SchoolManagement.Data;
using SchoolManagement.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Repository.EnrollmentRepository
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly SchoolDbContext _context;

        public EnrollmentRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Enrollment> GetByEnrollmentIdAsync(int studentId)
        {
            return await _context.Enrollments
                .FirstOrDefaultAsync(s => s.StudentId == studentId);
        }
    }
}