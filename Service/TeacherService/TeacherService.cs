using AutoMapper;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.TeacherRepository;


namespace SchoolManagement.Service.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeacherDto>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeacherDto>>(teachers);
        }

        public async Task<TeacherDto> GetByIdAsync(int id)
        {
            var teacherEntity = await _teacherRepository.GetByIdAsync(id);
            return teacherEntity == null ? null : _mapper.Map<TeacherDto>(teacherEntity);
        }

        public async Task<TeacherDto> CreateAsync(TeacherDto dto)
        {
            var entity = _mapper.Map<Teacher>(dto);
            await _teacherRepository.AddAsync(entity);
            await _teacherRepository.SaveChangesAsync();
            return _mapper.Map<TeacherDto>(entity);
        }

        public async Task<TeacherDto> UpdateAsync(int id, TeacherDto dto)
        {
            var existing = await _teacherRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _teacherRepository.Update(existing);
            await _teacherRepository.SaveChangesAsync();
            return _mapper.Map<TeacherDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _teacherRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _teacherRepository.Delete(entity);
            await _teacherRepository.SaveChangesAsync();
            return true;
        }
    }
}