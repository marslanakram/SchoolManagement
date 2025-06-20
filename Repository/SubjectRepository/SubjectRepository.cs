using SchoolManagement.Data.Entities;
using SchoolManagement.Data;
using SchoolManagement.Repository.GenericRepository;
using SchoolManagement.Repository.StudentRepository.StudentRepository;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Repository.SubjectRepository
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly SchoolDbContext _context;

        public SubjectRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Subject> GetBySubjectIdAsync(string name)
        {
            return await _context.Subjects
                .FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
