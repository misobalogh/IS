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

    public static readonly RegisteredActivitiesEntity Xmkrva01IDSProject = new()
    {
        Id = Guid.Parse("eadf7a13-db18-4be6-bc2a-302a21df5bee"),
        StudentId = StudentSeeds.Xmrkva01.Id,
        Student = StudentSeeds.Xmrkva01,
        ActivityId = ActivitySeeds.IDSProject.Id,
        Activity = ActivitySeeds.IDSProject,
    };

    public static readonly RegisteredActivitiesEntity Xmrkva01IISProject = new()
    {
        Id = Guid.Parse("397c4f82-dbfd-4687-8d40-720d79a0b678"),
        StudentId = StudentSeeds.Xmrkva01.Id,
        Student = StudentSeeds.Xmrkva01,
        ActivityId = ActivitySeeds.IISProject.Id,
        Activity = ActivitySeeds.IISProject,
    };

    public static readonly RegisteredActivitiesEntity Xmrkva01IFJMidterm = new()
    {
        Id = Guid.Parse("845aab54-8a3e-4d83-82b0-f83db7a41695"),
        StudentId = StudentSeeds.Xmrkva01.Id,
        Student = StudentSeeds.Xmrkva01,
        ActivityId = ActivitySeeds.IFJMidterm.Id,
        Activity = ActivitySeeds.IFJMidterm,
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<RegisteredActivitiesEntity>().HasData(
            Xplagi00IFJMidterm with { Activity = null!, Student = null! },
            Xmrkva01IJCConsultation with { Activity = null!, Student = null! },
            Xmkrva01IDSProject with { Activity = null!, Student = null! },
            Xmrkva01IISProject with { Activity = null!, Student = null! },
            Xmrkva01IFJMidterm with { Activity = null!, Student = null! }
        );
}
