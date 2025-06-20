using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.GenericRepository;

namespace SchoolManagement.Repository.AttendanceRepository
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        Task<Attendance> GetByAttendanceIdAsync(int studentId);
    }
}