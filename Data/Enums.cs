using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Data
{
    public class Enums  // ✅ Capitalize class name to follow C# conventions
    {
        public enum GradeLevel
        {
            [Display(Name = "Play Group")]
            PlayGroup,

            [Display(Name = "Nursery")]
            Nursery,

            [Display(Name = "Prep / KG")]
            Prep,

            [Display(Name = "1st")]
            First,

            [Display(Name = "2nd")]
            Second,

            [Display(Name = "3rd")]
            Third,

            [Display(Name = "4th")]
            Fourth,

            [Display(Name = "5th")]
            Fifth,

            [Display(Name = "6th")]
            Sixth,

            [Display(Name = "7th")]
            Seventh,

            [Display(Name = "8th")]
            Eighth,

            [Display(Name = "9th")]
            Ninth,

            [Display(Name = "10th")]
            Tenth,

            [Display(Name = "11th (First Year)")]
            Eleventh,

            [Display(Name = "12th (Second Year)")]
            Twelfth
        }

        public enum Section
        {
            A,
            B,
            C,
            D
        }
    }
}
