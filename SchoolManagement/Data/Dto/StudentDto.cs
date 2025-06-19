using SchoolManagement.Data.Entities;

namespace SchoolManagement.Data.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string StudentId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int? CurrentClassId { get; set; }

    }
}
