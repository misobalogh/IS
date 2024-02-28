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
}