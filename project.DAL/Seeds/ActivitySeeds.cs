using project.DAL.Entities;
using project.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace project.DAL.Seeds;

public static class ActivitySeeds
{
    public static readonly ActivityEntity IJCConsultation = new()
    {
        Id = Guid.Parse("21adbcf5-f96d-4943-8249-d73401395a06"),
        ActivityType = ActivityType.Consultation,
        Start = DateTime.Today,
        End = DateTime.Today,
        Room = Room.A01,
        SubjectId = SubjectSeeds.IJC.Id,
        Subject = SubjectSeeds.IJC,
    };
    
    public static readonly ActivityEntity IFJMidterm = new()
    {
        Id = Guid.Parse("fc6e2571-362d-47fd-8a61-fc3dc08d486f"),
        ActivityType = ActivityType.MidtermExam,
        Start = DateTime.Today,
        End = DateTime.Today,
        Room = Room.C01,
        SubjectId = SubjectSeeds.IFJ.Id,
        Subject = SubjectSeeds.IFJ,
        EvaluationId = EvaluationSeeds.IFJMidterm.Id,
        Evaluation = EvaluationSeeds.IFJMidterm,
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<ActivityEntity>().HasData(
            IFJMidterm with { Subject = null!, Evaluation = null! },
            IJCConsultation with { Subject = null!, Evaluation = null! }
        );
}
