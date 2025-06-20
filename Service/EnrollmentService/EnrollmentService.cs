using AutoMapper;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.EnrollmentRepository;

namespace SchoolManagement.Service.EnrollmentService
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMapper _mapper;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EnrollmentDto>> GetAllAsync()
        {
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
        }

        public async Task<EnrollmentDto> GetByIdAsync(int id)
        {
            var enrollmentEntity = await _enrollmentRepository.GetByIdAsync(id);
            return enrollmentEntity == null ? null : _mapper.Map<EnrollmentDto>(enrollmentEntity);
        }

        public async Task<EnrollmentDto> CreateAsync(EnrollmentDto dto)
        {
            var entity = _mapper.Map<Enrollment>(dto);
            await _enrollmentRepository.AddAsync(entity);
            await _enrollmentRepository.SaveChangesAsync();
            return _mapper.Map<EnrollmentDto>(entity);
        }

        public async Task<EnrollmentDto> UpdateAsync(int id, EnrollmentDto dto)
        {
            var existing = await _enrollmentRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _enrollmentRepository.Update(existing);
            await _enrollmentRepository.SaveChangesAsync();
            return _mapper.Map<EnrollmentDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _enrollmentRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _enrollmentRepository.Delete(entity);
            await _enrollmentRepository.SaveChangesAsync();
            return true;
        }
    }
}