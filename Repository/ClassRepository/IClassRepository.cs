using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.GenericRepository;

namespace SchoolManagement.Repository.ClassRepository
{
    public interface IClassRepository : IGenericRepository<Class>
    {
        Task<Class> GetByClassIdAsync(string classId);
    }
}