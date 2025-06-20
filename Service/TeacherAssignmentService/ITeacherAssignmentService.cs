using SchoolManagement.Data.Dto;

namespace SchoolManagement.Service.TeacherAssignmentService
{
    public interface ITeacherAssignmentService
    {

        Task<IEnumerable<TeacherAssignmentDto>> GetAllAsync();
        Task<TeacherAssignmentDto> GetByIdAsync(int id);
        Task<TeacherAssignmentDto> CreateAsync(TeacherAssignmentDto dto);
        Task<TeacherAssignmentDto> UpdateAsync(int id, TeacherAssignmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
