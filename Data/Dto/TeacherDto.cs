namespace SchoolManagement.Data.Dto
{
    public class TeacherDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string TeacherId { get; set; }
        
        public string FirstName { get; set; }  

        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public string? Specialization { get; set; }

        public string? PhoneNumber { get; set; }    

        public string? Email { get; set; }          

        public string? Address { get; set; }      

        public string? Qualifications { get; set; } 

        public string? Bio { get; set; }

        public string? Gender { get; set; }

        public string? PhotoUrl { get; set; }       


        public bool IsActive { get; set; } = true;   

        public DateTime? EndDate { get; set; }       
    }
}
