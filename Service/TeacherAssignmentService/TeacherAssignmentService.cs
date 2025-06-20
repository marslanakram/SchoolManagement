using AutoMapper;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.TeacherAssignmentRepository;

namespace SchoolManagement.Service.TeacherAssignmentService
{
    public class TeacherAssignmentService : ITeacherAssignmentService
    {
        private readonly ITeacherAssignmentRepository _teacherAssignmentRepository;
        private readonly IMapper _mapper;

        public TeacherAssignmentService(ITeacherAssignmentRepository teacherAssignmentRepository, IMapper mapper)
        {
            _teacherAssignmentRepository = teacherAssignmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeacherAssignmentDto>> GetAllAsync()
        {
            var teacherAssignments = await _teacherAssignmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeacherAssignmentDto>>(teacherAssignments);
        }

        public async Task<TeacherAssignmentDto> GetByIdAsync(int id)
        {
            var teacherAssignmentEntity = await _teacherAssignmentRepository.GetByIdAsync(id);
            return teacherAssignmentEntity == null ? null : _mapper.Map<TeacherAssignmentDto>(teacherAssignmentEntity);
        }

        public async Task<TeacherAssignmentDto> CreateAsync(TeacherAssignmentDto dto)
        {
            var entity = _mapper.Map<TeacherAssignment>(dto);
            await _teacherAssignmentRepository.AddAsync(entity);
            await _teacherAssignmentRepository.SaveChangesAsync();
            return _mapper.Map<TeacherAssignmentDto>(entity);
        }

        public async Task<TeacherAssignmentDto> UpdateAsync(int id, TeacherAssignmentDto dto)
        {
            var existing = await _teacherAssignmentRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _teacherAssignmentRepository.Update(existing);
            await _teacherAssignmentRepository.SaveChangesAsync();
            return _mapper.Map<TeacherAssignmentDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _teacherAssignmentRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _teacherAssignmentRepository.Delete(entity);
            await _teacherAssignmentRepository.SaveChangesAsync();
            return true;
        }
    }
}