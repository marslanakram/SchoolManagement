using SchoolManagement.Data.Dto;

namespace SchoolManagement.Service.SubjectService
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllAsync();
        Task<SubjectDto> GetByIdAsync(int id);
        Task<SubjectDto> CreateAsync(SubjectDto dto);
        Task<SubjectDto> UpdateAsync(int id, SubjectDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
