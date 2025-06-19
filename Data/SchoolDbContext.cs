using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using System.Linq.Expressions;

namespace SchoolManagement.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        // DbSets
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

            // ✅ Composite Keys

            // Grade: (StudentId, SubjectId, GradingPeriod)
            modelBuilder.Entity<Grade>()
                .HasIndex(g => new { g.StudentId, g.SubjectId, g.GradingPeriod })
                .IsUnique();

            // Enrollment: (StudentId, ClassId)
            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.ClassId })
                .IsUnique();

            // TeacherAssignment: (TeacherId, SubjectId, ClassId)
            modelBuilder.Entity<TeacherAssignment>()
                .HasIndex(ta => new { ta.TeacherId, ta.SubjectId, ta.ClassId })
                .IsUnique();

            // Attendance: One per student per class per day
            modelBuilder.Entity<Attendance>()
                .HasIndex(a => new { a.StudentId, a.ClassId, a.Date })
                .IsUnique();

            // ✅ Soft Delete Global Filter
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var param = Expression.Parameter(entityType.ClrType, "e");
                    var isDeleted = Expression.Property(param, nameof(BaseEntity.IsDeleted));
                    var filter = Expression.Lambda(
                        Expression.Equal(isDeleted, Expression.Constant(false)),
                        param
                    );
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
                }
            }
        }
    }
}
