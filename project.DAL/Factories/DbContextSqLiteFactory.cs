using Microsoft.EntityFrameworkCore;

namespace project.DAL.Factories;

public class DbContextSqLiteFactory : IDbContextFactory<ApplicationDbContext>
{
    private readonly bool _seedTestingData;
    private readonly DbContextOptionsBuilder<ApplicationDbContext> _contextOptionsBuilder = new();

    public DbContextSqLiteFactory(string databaseName, bool seedTestingData = false)
    {
        _seedTestingData = seedTestingData;

        _contextOptionsBuilder.UseSqlite($"Data Source={databaseName};Cache=Shared");

        ////Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
        //_contextOptionsBuilder.EnableSensitiveDataLogging();
        //_contextOptionsBuilder.LogTo(Console.WriteLine);
    }

    public ApplicationDbContext CreateDbContext() => new(_contextOptionsBuilder.Options, _seedTestingData);
}
