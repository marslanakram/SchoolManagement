using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.GenericRepository;

namespace SchoolManagement.Repository.GradeRepository
{
    public interface IGradeRepository : IGenericRepository<Grade>
    {
        Task<Grade> GetByGradeIdAsync(int studentId);
    }
}