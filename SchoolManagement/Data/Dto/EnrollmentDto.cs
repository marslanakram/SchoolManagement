using SchoolManagement.Data.Entities;

namespace SchoolManagement.Data.Dto
{
    public class EnrollmentDto
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
