using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.GenericRepository;

namespace SchoolManagement.Repository.TeacherRepository
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<Teacher> GetByTeacherIdAsync(string TeacherId);
    }
}