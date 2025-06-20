using AutoMapper;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.SubjectRepository;


namespace SchoolManagement.Service.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectrepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectrepository, IMapper mapper)
        {
            _subjectrepository = subjectrepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectDto>> GetAllAsync()
        {
            var subjects = await _subjectrepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public async Task<SubjectDto> GetByIdAsync(int id)
        {
            var subject = await _subjectrepository.GetByIdAsync(id);
            return subject == null ? null : _mapper.Map<SubjectDto>(subject);
        }

        public async Task<SubjectDto> CreateAsync(SubjectDto dto)
        {
            var entity = _mapper.Map<Subject>(dto);
            await _subjectrepository.AddAsync(entity);
            await _subjectrepository.SaveChangesAsync();
            return _mapper.Map<SubjectDto>(entity);
        }

        public async Task<SubjectDto> UpdateAsync(int id, SubjectDto dto)
        {
            var existing = await _subjectrepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _subjectrepository.Update(existing);
            await _subjectrepository.SaveChangesAsync();
            return _mapper.Map<SubjectDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _subjectrepository.GetByIdAsync(id);
            if (entity == null) return false;

            _subjectrepository.Delete(entity);
            await _subjectrepository.SaveChangesAsync();
            return true;
        }
    }
}