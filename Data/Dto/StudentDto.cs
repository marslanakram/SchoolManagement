using SchoolManagement.Data.Entities;

namespace SchoolManagement.Data.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }                    
        
        public string RollNumber { get; set; }             

        public string FirstName { get; set; }            

        public string LastName { get; set; }            

        public string? Email { get; set; }               

        public string? PhoneNumber { get; set; }         

        public string? Address { get; set; }             

        public DateTime DateOfBirth { get; set; }         

        public string? Gender { get; set; }              

        public string? BloodGroup { get; set; }           

        public string? GuardianName { get; set; }        

        public string? GuardianContact { get; set; }      

        public DateTime EnrollmentDate { get; set; }     

        public bool IsActive { get; set; } = true;        

        public string? PhotoUrl { get; set; }           

        public int? CurrentClassId { get; set; }

    }
}
