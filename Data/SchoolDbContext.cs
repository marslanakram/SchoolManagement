using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using System.Linq.Expressions;

namespace SchoolManagement.Data
{
    public class SchoolDbContext : DbContext
    {

        //  dotnet ef migrations remove
        //  dotnet ef migrations add InitialCreate
        //  dotnet ef database update
        //dotnet ef migrations add AddGradeLevelAndSectionToClass
        //Update-Database
        //dotnet build


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

            // One-to-one User <-> Teacher
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne(u => u.TeacherProfile)
                .HasForeignKey<Teacher>(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Composite indexes
            modelBuilder.Entity<Grade>()
                .HasIndex(g => new { g.StudentId, g.SubjectId, g.GradingPeriod })
                .IsUnique();

            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.ClassId })
                .IsUnique();

            modelBuilder.Entity<TeacherAssignment>()
                .HasIndex(ta => new { ta.TeacherId, ta.SubjectId, ta.ClassId })
                .IsUnique();

            modelBuilder.Entity<Attendance>()
                .HasIndex(a => new { a.StudentId, a.ClassId, a.Date })
                .IsUnique();

            modelBuilder.Entity<Class>()
                   .Property(c => c.GradeLevel)
                   .HasConversion<string>();

            modelBuilder.Entity<Class>()
                .Property(c => c.Section)
                .HasConversion<string>();

            ApplyGlobalSoftDeleteFilter(modelBuilder);
        }

        private void ApplyGlobalSoftDeleteFilter(ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType) && e.BaseType == null);

            foreach (var entityType in entityTypes)
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
                var compare = Expression.Equal(property, Expression.Constant(false));
                var lambda = Expression.Lambda(compare, parameter);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
    }
}
