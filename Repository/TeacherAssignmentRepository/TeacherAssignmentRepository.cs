using SchoolManagement.Data.Entities;
using SchoolManagement.Data;
using SchoolManagement.Repository.GenericRepository;
using SchoolManagement.Repository.SchoolEventRepository;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Repository.TeacherAssignmentRepository
{
    public class TeacherAssignmentRepository : GenericRepository<TeacherAssignment>, ITeacherAssignmentRepository
    {
        private readonly SchoolDbContext _context;

        public TeacherAssignmentRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TeacherAssignment> GetByTeacherAssignmentIdAsync(int classId)
        {
            return await _context.TeacherAssignments
                .FirstOrDefaultAsync(s => s.ClassId == classId);
        }
    }
}