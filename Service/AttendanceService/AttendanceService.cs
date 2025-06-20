using AutoMapper;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.AttendanceRepository;

namespace SchoolManagement.Service.AttendanceService
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttendanceDto>> GetAllAsync()
        {
            var attendance = await _attendanceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AttendanceDto>>(attendance);
        }

        public async Task<AttendanceDto> GetByIdAsync(int id)
        {
            var attendanceEntity = await _attendanceRepository.GetByIdAsync(id);
            return attendanceEntity == null ? null : _mapper.Map<AttendanceDto>(attendanceEntity);
        }

        public async Task<AttendanceDto> CreateAsync(AttendanceDto dto)
        {
            var entity = _mapper.Map<Attendance>(dto);
            await _attendanceRepository.AddAsync(entity);
            await _attendanceRepository.SaveChangesAsync();
            return _mapper.Map<AttendanceDto>(entity);
        }

        public async Task<AttendanceDto> UpdateAsync(int id, AttendanceDto dto)
        {
            var existing = await _attendanceRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _attendanceRepository.Update(existing);
            await _attendanceRepository.SaveChangesAsync();
            return _mapper.Map<AttendanceDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _attendanceRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _attendanceRepository.Delete(entity);
            await _attendanceRepository.SaveChangesAsync();
            return true;
        }
    }
}