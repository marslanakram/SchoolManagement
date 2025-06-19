using SchoolManagement.Data.Entities;

namespace SchoolManagement.Data.Dto
{
    public class EnrollmentDto
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
       
        public int ClassId { get; set; }
     
        public DateTime EnrollmentDate { get; set; }

        public bool IsActive { get; set; }
    }
}
