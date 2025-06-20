using SchoolManagement.Data.Dto;

namespace SchoolManagement.Service.EnrollmentService
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentDto>> GetAllAsync();
        Task<EnrollmentDto> GetByIdAsync(int id);
        Task<EnrollmentDto> CreateAsync(EnrollmentDto dto);
        Task<EnrollmentDto> UpdateAsync(int id, EnrollmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
