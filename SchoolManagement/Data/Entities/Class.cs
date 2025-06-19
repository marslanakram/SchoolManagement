namespace SchoolManagement.Data.Entities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AcademicYear { get; set; }
        public int? HomeroomTeacherId { get; set; }
        public Teacher HomeroomTeacher { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<TeacherAssignment> TeacherAssignments { get; set; }
    }
