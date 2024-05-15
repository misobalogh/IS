using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace project.DAL.Seeds;

public static class EvaluationSeeds
{
    public static readonly EvaluationEntity IFJMidterm = new()
    {
        Id = Guid.Parse("18bbc9de-444a-4099-9a3b-f77e44162f4a"),
        Points = 10,
        Student = StudentSeeds.Xmrkva01,
        StudentId = StudentSeeds.Xmrkva01.Id,
        ActivityId = ActivitySeeds.IFJMidterm.Id,
        Activity = ActivitySeeds.IFJMidterm
    };

    public static readonly EvaluationEntity IISProject = new()
    {
        Id = Guid.Parse("50fcc755-0509-4869-9775-20cc913f956d"),
        Points = 20,
        Student = StudentSeeds.Xmrkva01,
        StudentId = StudentSeeds.Xmrkva01.Id,
        ActivityId = ActivitySeeds.IISProject.Id,
        Activity = ActivitySeeds.IISProject
    };

    public static readonly EvaluationEntity IDSProject = new()
    {
        Id = Guid.Parse("2f7a84d3-bce6-46ad-88c0-252662c7d21f"),
        Points = 30,
        Student = StudentSeeds.Xmrkva01,
        StudentId = StudentSeeds.Xmrkva01.Id,
        ActivityId = ActivitySeeds.IDSProject.Id,
        Activity = ActivitySeeds.IDSProject
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<EvaluationEntity>().HasData(
            IFJMidterm with { Student = null!, Activity = null! },
            IISProject with { Student = null!, Activity = null! },
            IDSProject with { Student = null!, Activity = null! }
            );
}
