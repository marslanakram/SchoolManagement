using SchoolManagement.Data.Entities;

namespace SchoolManagement.Data.Dto
{
    public class TeacherAssignmentDto
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

      
        public int SubjectId { get; set; }

       
        public int ClassId { get; set; }

        
        public DateTime AssignmentDate { get; set; }

        public string Schedule { get; set; }
    }
}
