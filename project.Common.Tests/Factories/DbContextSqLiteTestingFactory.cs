using project.DAL;
using Microsoft.EntityFrameworkCore;

namespace project.Common.Tests.Factories;

public class DbContextSqLiteTestingFactory(string databaseName, bool seedTestingData = false)
    : IDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext()
    {
        DbContextOptionsBuilder<ApplicationDbContext> builder = new();
        builder.UseSqlite($"Data Source={databaseName};Cache=Shared");

        // builder.LogTo(Console.WriteLine); //Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
        // builder.EnableSensitiveDataLogging();

        return new ApplicationTestingDbContext(builder.Options, seedTestingData);
    }
}
