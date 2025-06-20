using AutoMapper;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.ClassRepository;

namespace SchoolManagement.Service.ClassService
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassService(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassDto>> GetAllAsync()
        {
            var classes = await _classRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClassDto>>(classes);
        }

        public async Task<ClassDto> GetByIdAsync(int id)
        {
            var classEntity = await _classRepository.GetByIdAsync(id);
            return classEntity == null ? null : _mapper.Map<ClassDto>(classEntity);
        }

        public async Task<ClassDto> CreateAsync(ClassDto dto)
        {
            var entity = _mapper.Map<Class>(dto);
            await _classRepository.AddAsync(entity);
            await _classRepository.SaveChangesAsync();
            return _mapper.Map<ClassDto>(entity);
        }

        public async Task<ClassDto> UpdateAsync(int id, ClassDto dto)
        {
            var existing = await _classRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _classRepository.Update(existing);
            await _classRepository.SaveChangesAsync();
            return _mapper.Map<ClassDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _classRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _classRepository.Delete(entity);
            await _classRepository.SaveChangesAsync();
            return true;
        }
    }
}