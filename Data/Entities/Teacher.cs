namespace SchoolManagement.Data.Entities
{
    public class Teacher : User
    {
        public string TeacherId { get; set; }
        public DateTime HireDate { get; set; }
        public string Specialization { get; set; }
        public ICollection<TeacherAssignment> TeacherAssignments { get; set; }
    }
}
