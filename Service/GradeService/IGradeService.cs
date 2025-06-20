using SchoolManagement.Data.Dto;

namespace SchoolManagement.Service.GradeService
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeDto>> GetAllAsync();
        Task<GradeDto> GetByIdAsync(int id);
        Task<GradeDto> CreateAsync(GradeDto dto);
        Task<GradeDto> UpdateAsync(int id, GradeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
