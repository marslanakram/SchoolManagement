using SchoolManagement.Data.Entities;

namespace SchoolManagement.Data.Dto
{
    public class StudentDto
    {
        public string StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int? CurrentClassId { get; set; }
        public Class CurrentClass { get; set; }
    }
}
