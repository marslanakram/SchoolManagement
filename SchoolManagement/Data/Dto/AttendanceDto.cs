using SchoolManagement.Data.Entities;

namespace SchoolManagement.Data.Dto
{
    public class AttendanceDto
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public string Notes { get; set; }
    }
}
