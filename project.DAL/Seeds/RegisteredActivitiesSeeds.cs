using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace project.DAL.Seeds;

public static class RegisteredActivitiesSeeds
{
    public static readonly RegisteredActivitiesEntity Xplagi00IFJMidterm = new()
    {
        Id = Guid.Parse("173e971f-b7a4-4eec-944d-c1ddea94c3c6"),
        StudentId = StudentSeeds.Xplagi00.Id,
        Student = StudentSeeds.Xplagi00,
        ActivityId = ActivitySeeds.IFJMidterm.Id,
        Activity = ActivitySeeds.IFJMidterm,
    };
    
    public static readonly RegisteredActivitiesEntity Xmrkva01IJCConsultation = new()
    {
        Id = Guid.Parse("2a484e4f-c3d4-4a57-8f21-c8751cc16d2e"),
        StudentId = StudentSeeds.Xmrkva01.Id,
        Student = StudentSeeds.Xmrkva01,
        ActivityId = ActivitySeeds.IJCConsultation.Id,
        Activity = ActivitySeeds.IJCConsultation,
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<RegisteredActivitiesEntity>().HasData(
            Xplagi00IFJMidterm with { Activity = null!, Student = null! },
            Xmrkva01IJCConsultation with { Activity = null!, Student = null! }
        );
}
