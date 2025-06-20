using SchoolManagement.Data.Dto;

namespace SchoolManagement.Service.SchoolEventService
{
    public interface ISchoolEventService
    {
        Task<IEnumerable<SchoolEventDto>> GetAllAsync();
        Task<SchoolEventDto> GetByIdAsync(int id);
        Task<SchoolEventDto> CreateAsync(SchoolEventDto dto);
        Task<SchoolEventDto> UpdateAsync(int id, SchoolEventDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
