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
            
        }
    }
}
