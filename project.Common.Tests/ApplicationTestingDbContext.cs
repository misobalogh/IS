using Microsoft.EntityFrameworkCore;
using project.DAL;
using project.Common.Tests.Seeds;

namespace project.Common.Tests;

public class ApplicationTestingDbContext(DbContextOptions contextOptions, bool seedTestingData = false)
    : ApplicationDbContext(contextOptions, seedDemoData: false)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        if (seedTestingData)
        {
            SubjectSeeds.Seed(modelBuilder);
            TeacherSeeds.Seed(modelBuilder);
            TeachingSubjectsSeeds.Seed(modelBuilder);
            RegisteredSubjectsSeeds.Seed(modelBuilder);
            RegisteredActivitiesSeeds.Seed(modelBuilder);
            StudentSeeds.Seed(modelBuilder);
            ActivitySeeds.Seed(modelBuilder);
            EvaluationSeeds.Seed(modelBuilder);
        }
    }
}
