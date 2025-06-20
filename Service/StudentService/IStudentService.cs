using SchoolManagement.Data.Dto;

namespace SchoolManagement.Service.StudentService
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto> GetByIdAsync(int id);
        Task<StudentDto> CreateAsync(StudentDto dto);
        Task<StudentDto> UpdateAsync(int id, StudentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
