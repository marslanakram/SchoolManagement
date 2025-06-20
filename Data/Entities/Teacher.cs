namespace SchoolManagement.Data.Entities
{
    public class Teacher : BaseEntity
    {
        public string TeacherId { get; set; }
        public DateTime HireDate { get; set; }
        public string Specialization { get; set; }
        // Foreign Key
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<TeacherAssignment> TeacherAssignments { get; set; }
    }
}
