namespace SchoolManagement.Data.Dto
{
    public class TeacherDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string TeacherId { get; set; }

        public DateTime HireDate { get; set; }

        public string Specialization { get; set; }
    }
}
