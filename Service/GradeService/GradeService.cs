using AutoMapper;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.GradeRepository;


namespace SchoolManagement.Service.GradeService
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradeService(IGradeRepository gradeRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GradeDto>> GetAllAsync()
        {
            var grades = await _gradeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GradeDto>>(grades);
        }

        public async Task<GradeDto> GetByIdAsync(int id)
        {
            var gradeEntity = await _gradeRepository.GetByIdAsync(id);
            return gradeEntity == null ? null : _mapper.Map<GradeDto>(gradeEntity);
        }

        public async Task<GradeDto> CreateAsync(GradeDto dto)
        {
            var entity = _mapper.Map<Grade>(dto);
            await _gradeRepository.AddAsync(entity);
            await _gradeRepository.SaveChangesAsync();
            return _mapper.Map<GradeDto>(entity);
        }

        public async Task<GradeDto> UpdateAsync(int id, GradeDto dto)
        {
            var existing = await _gradeRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _gradeRepository.Update(existing);
            await _gradeRepository.SaveChangesAsync();
            return _mapper.Map<GradeDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _gradeRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _gradeRepository.Delete(entity);
            await _gradeRepository.SaveChangesAsync();
            return true;
        }
    }
}