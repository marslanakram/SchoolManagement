using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.GenericRepository;

namespace SchoolManagement.Repository.SchoolEventRepository
{
    public interface ISchoolEventRepository : IGenericRepository<SchoolEvent>
    {
        Task<SchoolEvent> GetBySchoolEventIdAsync(int classId);
    }
}