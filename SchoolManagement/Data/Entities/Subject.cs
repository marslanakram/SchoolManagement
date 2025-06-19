namespace SchoolManagement.Data.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ICollection<TeacherAssignment> TeacherAssignments { get; set; }
    }
}
