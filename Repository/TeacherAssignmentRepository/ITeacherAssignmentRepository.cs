using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.GenericRepository;

namespace SchoolManagement.Repository.TeacherAssignmentRepository
{
    public interface ITeacherAssignmentRepository : IGenericRepository<TeacherAssignment>
    {
        Task<TeacherAssignment> GetByTeacherAssignmentIdAsync(int classId);
    }
}