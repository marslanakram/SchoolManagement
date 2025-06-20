using SchoolManagement.Data.Entities;
using SchoolManagement.Data;
using SchoolManagement.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Repository.AttendanceRepository
{
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        private readonly SchoolDbContext _context;

        public AttendanceRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Attendance> GetByAttendanceIdAsync(int studentId)
        {
            return await _context.Attendances
                .FirstOrDefaultAsync(s => s.StudentId == studentId);
        }
    }
}