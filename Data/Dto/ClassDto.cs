using SchoolManagement.Data.Entities;

namespace SchoolManagement.Data.Dto
{
    public class ClassDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int AcademicYear { get; set; }

        public int? HomeroomTeacherId { get; set; }


    }
}
