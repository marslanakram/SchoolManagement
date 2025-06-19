namespace SchoolManagement.Data.Entities
{
    public class Attendance : BaseEntity
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
