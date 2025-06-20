using AutoMapper;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Repository.StudentRepository.StudentRepository;

namespace SchoolManagement.Service.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentrepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentrepository, IMapper mapper)
        {
            _studentrepository = studentrepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _studentrepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await _studentrepository.GetByIdAsync(id);
            return student == null ? null : _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> CreateAsync(StudentDto dto)
        {
            var entity = _mapper.Map<Student>(dto);
            await _studentrepository.AddAsync(entity);
            await _studentrepository.SaveChangesAsync();
            return _mapper.Map<StudentDto>(entity);
        }

        public async Task<StudentDto> UpdateAsync(int id, StudentDto dto)
        {
            var existing = await _studentrepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _studentrepository.Update(existing);
            await _studentrepository.SaveChangesAsync();
            return _mapper.Map<StudentDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _studentrepository.GetByIdAsync(id);
            if (entity == null) return false;

            _studentrepository.Delete(entity);
            await _studentrepository.SaveChangesAsync();
            return true;
        }
    }
}
