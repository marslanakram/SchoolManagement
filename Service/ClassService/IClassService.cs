using SchoolManagement.Data.Dto;

namespace SchoolManagement.Service.ClassService
{
    public interface IClassService
    {
        Task<IEnumerable<ClassDto>> GetAllAsync();
        Task<ClassDto> GetByIdAsync(int id);
        Task<ClassDto> CreateAsync(ClassDto dto);
        Task<ClassDto> UpdateAsync(int id, ClassDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
