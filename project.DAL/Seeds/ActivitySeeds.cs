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
        Start = new DateTime(2024, 05, 14, 08, 00, 00),
        End = new DateTime(2024, 05, 14, 09, 00, 00),
        Room = Room.A01,
        SubjectId = SubjectSeeds.IJC.Id,
        Subject = SubjectSeeds.IJC,
        Name = "IJC",
        Capacity = 1,
        MaxPoints = null,
        TeacherId = TeacherSeeds.Chrobak.Id,
        Teacher = TeacherSeeds.Chrobak,
    };
    
    public static readonly ActivityEntity IFJMidterm = new()
    {
        Id = Guid.Parse("fc6e2571-362d-47fd-8a61-fc3dc08d486f"),
        ActivityType = ActivityType.MidtermExam,
        Start = new DateTime(2024, 05, 13, 08, 00, 00),
        End = new DateTime(2024, 05, 13, 09, 00, 00),
        Room = Room.C01,
        SubjectId = SubjectSeeds.IFJ.Id,
        Subject = SubjectSeeds.IFJ,
        Name = "IFJ",
        Capacity = 100,
        MaxPoints = 10,
        TeacherId = TeacherSeeds.Lienka.Id,
        Teacher = TeacherSeeds.Lienka,
    };

    public static readonly ActivityEntity IDSProject = new()
    {
        Id = Guid.Parse("d43acf95-447d-4169-9de0-10df4fbf1222"),
        ActivityType = ActivityType.Project,
        Start = DateTime.Today,
        End = DateTime.Today,
        Room = Room.Online,
        SubjectId = SubjectSeeds.IDS.Id,
        Subject = SubjectSeeds.IDS,
        Name = "IDS",
        Capacity = 10,
        MaxPoints = 100,
        TeacherId = TeacherSeeds.Chrobak.Id,
        Teacher = TeacherSeeds.Chrobak,
    };

    public static readonly ActivityEntity IISLecture = new()
    {
        Id = Guid.Parse("07d710b6-f888-4544-9699-1b8351b2f5ef"),
        ActivityType = ActivityType.Lecture,
        Start = DateTime.Today,
        End = DateTime.Today,
        Room = Room.D01,
        SubjectId = SubjectSeeds.IIS.Id,
        Subject = SubjectSeeds.IIS,
        Name = "IIS",
        Capacity = 100,
        MaxPoints = null,
        TeacherId = TeacherSeeds.Novak.Id,
        Teacher = TeacherSeeds.Novak,
    };

    public static readonly ActivityEntity IISProject = new()
    {
        Id = Guid.Parse("fbade23f-82ee-4895-9ba3-cdad7de473c9"),
        ActivityType = ActivityType.Project,
        Start = DateTime.Today,
        End = DateTime.Today,
        Room = Room.Online,
        SubjectId = SubjectSeeds.IIS.Id,
        Subject = SubjectSeeds.IIS,
        Name = "IIS",
        Capacity = 10,
        MaxPoints = 100,
        TeacherId = TeacherSeeds.Novak.Id,
        Teacher = TeacherSeeds.Novak,
    };

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<ActivityEntity>().HasData(
            IFJMidterm with { Subject = null!, Teacher = null! },
            IJCConsultation with { Subject = null!, Teacher = null! },
            IDSProject with { Subject = null!, Teacher = null! },
            IISLecture with { Subject = null!, Teacher = null! },
            IISProject with { Subject = null!, Teacher = null! }
        );
}
