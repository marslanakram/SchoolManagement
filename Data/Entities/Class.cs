using System.ComponentModel.DataAnnotations.Schema;
using static SchoolManagement.Data.Enums;

namespace SchoolManagement.Data.Entities
{
    public class Class : BaseEntity
    {
        [NotMapped]
        public string Name => $"{GradeLevel}-{Section}";
        public string Description { get; set; }
        public int AcademicYear { get; set; }
        public GradeLevel? GradeLevel { get; set; }    // e.g. "Grade 10"
        public Section? Section { get; set; }       // e.g. "A"
        public int? HomeroomTeacherId { get; set; }
        public Teacher HomeroomTeacher { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<TeacherAssignment> TeacherAssignments { get; set; } = new List<TeacherAssignment>();
    }

}
