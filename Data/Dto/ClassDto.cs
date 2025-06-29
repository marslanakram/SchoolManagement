using SchoolManagement.Data.Entities;
using static SchoolManagement.Data.Enums;

namespace SchoolManagement.Data.Dto
{
    public class ClassDto
    {
        public int Id { get; set; }

        public string? Name => $"{GradeLevel}-{Section}";

        public string? Description { get; set; }

        public int AcademicYear { get; set; }

        public GradeLevel? GradeLevel { get; set; }

        public Section? Section { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? HomeroomTeacherId { get; set; }

        public bool IsActive { get; set; }


    }
}
