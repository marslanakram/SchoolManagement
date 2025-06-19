using SchoolManagement.Data.Entities;

namespace SchoolManagement.Data.Dto
{
    public class GradeDto
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
     
        public int SubjectId { get; set; }
    
        public int GradingPeriod { get; set; }

        public decimal Score { get; set; }

        public DateTime DateRecorded { get; set; }

        public string Notes { get; set; }
    }
}
