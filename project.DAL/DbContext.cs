using Microsoft.EntityFrameworkCore;
using project.DAL.Entities;

namespace project.DAL;

public class ApplicationDbContext(DbContextOptions contextOptions, bool seedDemoData = false)
    : DbContext(contextOptions)
{
    public DbSet<ActivityEntity> Activities => Set<ActivityEntity>();
    public DbSet<EvaluationEntity> Evaluations => Set<EvaluationEntity>();
    public DbSet<StudentEntity> Students => Set<StudentEntity>();
    public DbSet<SubjectEntity> Subjects => Set<SubjectEntity>();
    public DbSet<TeacherEntity> Teachers => Set<TeacherEntity>();
    public DbSet<RegisteredActivitiesEntity> RegisteredActivities => Set<RegisteredActivitiesEntity>();
    public DbSet<RegisteredSubjectEntity> RegisteredSubjects => Set<RegisteredSubjectEntity>();
    public DbSet<TeachingSubjectsEntity> TeachingSubjects => Set<TeachingSubjectsEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ActivityEntity>()
            .HasOne(i => i.Evaluation)
            .WithOne(i => i.Activity);

        modelBuilder.Entity<StudentEntity>()
            .HasMany(i => i.EnrolledSubjects)
            .WithOne(i => i.Student)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StudentEntity>()
            .HasMany(i => i.RegisteredActivities)
            .WithOne(i => i.Student)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TeacherEntity>()
            .HasMany(i => i.Subjects)
            .WithOne(i => i.Teacher)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
