using SchoolManagement.Data.Dto;

namespace SchoolManagement.Service.AttendanceService
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDto>> GetAllAsync();
        Task<AttendanceDto> GetByIdAsync(int id);
        Task<AttendanceDto> CreateAsync(AttendanceDto dto);
        Task<AttendanceDto> UpdateAsync(int id, AttendanceDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
