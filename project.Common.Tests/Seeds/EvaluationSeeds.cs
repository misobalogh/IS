using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace project.Common.Tests.Seeds;

public static class EvaluationSeeds
{
    public static readonly EvaluationEntity IFJMidterm = new()
    {
        Id = Guid.Parse("18bbc9de-444a-4099-9a3b-f77e44162f40"),
        Points = 10,
        Student = StudentSeeds.Xmrkva01,
        StudentId = StudentSeeds.Xmrkva01.Id,
        ActivityId = ActivitySeeds.IFJMidterm.Id,
        Activity = ActivitySeeds.IFJMidterm
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<EvaluationEntity>().HasData(
            IFJMidterm with { Student = null!, Activity = null! }
            );
}
