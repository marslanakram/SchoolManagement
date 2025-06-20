using SchoolManagement.Data.Entities;
using SchoolManagement.Data;
using SchoolManagement.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Repository.SchoolEventRepository
{
    public class SchoolEventRepository : GenericRepository<SchoolEvent>, ISchoolEventRepository
    {
        private readonly SchoolDbContext _context;

        public SchoolEventRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SchoolEvent> GetBySchoolEventIdAsync(int classId)
        {
            return await _context.SchoolEvents
                .FirstOrDefaultAsync(s => s.ClassId == classId);
        }
    }
}