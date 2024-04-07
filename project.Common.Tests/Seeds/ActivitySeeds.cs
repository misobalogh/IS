using project.DAL.Entities;
using project.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace project.Common.Tests.Seeds;

public static class ActivitySeeds
{
    public static readonly ActivityEntity IJCConsultation = new()
    {
        Id = Guid.Parse("21adbcf5-f96d-4943-8249-d73401395a00"),
        ActivityType = ActivityType.Consultation,
        Start = DateTime.Today,
        End = DateTime.Today,
        Room = Room.A01,
        SubjectId = SubjectSeeds.IJC.Id,
        Subject = SubjectSeeds.IJC,
        Name = "IJC Consultation",
        Capacity = 1,
        MaxPoints = null,
        TeacherId = TeacherSeeds.Chrobak.Id,
        Teacher = TeacherSeeds.Chrobak,
    };
    
    public static readonly ActivityEntity IFJMidterm = new()
    {
        Id = Guid.Parse("fc6e2571-362d-47fd-8a61-fc3dc08d4860"),
        ActivityType = ActivityType.MidtermExam,
        Start = DateTime.Today,
        End = DateTime.Today,
        Room = Room.C01,
        SubjectId = SubjectSeeds.IFJ.Id,
        Subject = SubjectSeeds.IFJ,
        Name = "IFJ Midterm",
        Capacity = 100,
        MaxPoints = 10,
        TeacherId = TeacherSeeds.Lienka.Id,
        Teacher = TeacherSeeds.Lienka,

    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<ActivityEntity>().HasData(
            IFJMidterm with { Subject = null!, Teacher = null! },
            IJCConsultation with { Subject = null!, Teacher = null! }
        );
}
