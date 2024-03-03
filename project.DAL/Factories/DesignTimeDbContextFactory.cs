using Microsoft.EntityFrameworkCore.Design;

namespace project.DAL.Factories;

/// <summary>
///     EF Core CLI migration generation uses this DbContext to create model and migration
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    private readonly DbContextSqLiteFactory _dbContextSqLiteFactory = new($"Data Source=project;Cache=Shared");

    public ApplicationDbContext CreateDbContext(string[] args) => _dbContextSqLiteFactory.CreateDbContext();
}
