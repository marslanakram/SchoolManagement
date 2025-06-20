using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.GenericRepository;

namespace SchoolManagement.Repository.SubjectRepository
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        Task<Subject> GetBySubjectIdAsync(string subjectId);
    }
}