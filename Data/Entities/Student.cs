using System.Diagnostics;
using System.Security.Claims;

namespace SchoolManagement.Data.Entities
{
    public class Student : BaseEntity
    {
        public string StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        // Foreign Key
        public int UserId { get; set; }
        public User User { get; set; }
        public int? CurrentClassId { get; set; }
        public Class CurrentClass { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
