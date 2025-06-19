using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<SchoolEvent> SchoolEvents { get; set; }
        public DbSet<TeacherAssignment> TeacherAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Fluent API configurations if needed
            modelBuilder.Entity<User>().HasDiscriminator<string>("Role")
                .HasValue<Student>("Student")
                .HasValue<Teacher>("Teacher");

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Enrollments)
                .WithOne(e => e.Class)
                .HasForeignKey(e => e.ClassId);

            modelBuilder.Entity<Class>()
                .HasMany(c => c.TeacherAssignments)
                .WithOne(ta => ta.Class)
                .HasForeignKey(ta => ta.ClassId);

            // Add other entity configurations as needed
        }
    }
}
