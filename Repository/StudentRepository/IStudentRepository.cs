using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.GenericRepository;

namespace SchoolManagement.Repository.StudentRepository.StudentRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> GetByStudentIdAsync(string studentId);
    }
}