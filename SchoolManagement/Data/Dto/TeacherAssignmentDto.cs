using SchoolManagement.Data.Entities;

namespace SchoolManagement.Data.Dto
{
    public class TeacherAssignmentDto
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string Schedule { get; set; }
    }
}
