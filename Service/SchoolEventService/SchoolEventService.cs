using AutoMapper;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.SchoolEventRepository;


namespace SchoolManagement.Service.SchoolEventService
{
    public class SchoolEventService : ISchoolEventService
    {
        private readonly ISchoolEventRepository _schoolEventRepository;
        private readonly IMapper _mapper;

        public SchoolEventService(ISchoolEventRepository schoolEventRepository, IMapper mapper)
        {
            _schoolEventRepository = schoolEventRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SchoolEventDto>> GetAllAsync()
        {
            var schoolEvents = await _schoolEventRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SchoolEventDto>>(schoolEvents);
        }

        public async Task<SchoolEventDto> GetByIdAsync(int id)
        {
            var schoolEventEntity = await _schoolEventRepository.GetByIdAsync(id);
            return schoolEventEntity == null ? null : _mapper.Map<SchoolEventDto>(schoolEventEntity);
        }

        public async Task<SchoolEventDto> CreateAsync(SchoolEventDto dto)
        {
            var entity = _mapper.Map<SchoolEvent>(dto);
            await _schoolEventRepository.AddAsync(entity);
            await _schoolEventRepository.SaveChangesAsync();
            return _mapper.Map<SchoolEventDto>(entity);
        }

        public async Task<SchoolEventDto> UpdateAsync(int id, SchoolEventDto dto)
        {
            var existing = await _schoolEventRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _schoolEventRepository.Update(existing);
            await _schoolEventRepository.SaveChangesAsync();
            return _mapper.Map<SchoolEventDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _schoolEventRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _schoolEventRepository.Delete(entity);
            await _schoolEventRepository.SaveChangesAsync();
            return true;
        }
    }
}