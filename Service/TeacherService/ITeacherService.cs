using SchoolManagement.Data.Dto;

namespace SchoolManagement.Service.TeacherService
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetAllAsync();
        Task<TeacherDto> GetByIdAsync(int id);
        Task<TeacherDto> CreateAsync(TeacherDto dto);
        Task<TeacherDto> UpdateAsync(int id, TeacherDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
