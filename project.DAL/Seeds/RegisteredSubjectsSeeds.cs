using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using project.DAL.Enums;

namespace project.DAL.Seeds;

public static class RegisteredSubjectsSeeds
{
    public static readonly EnrolledSubjectEntity Xplagi00IFJ = new()
    {
        Id = Guid.Parse("371a5d4a-c60d-4e45-b3a1-db2bca96b24e"),
        SubjectId = SubjectSeeds.IFJ.Id,
        StudentId = StudentSeeds.Xplagi00.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IFJ,
        Student = StudentSeeds.Xplagi00,
        Points = 0,
        Mark = Mark.None
    };
    
    public static readonly EnrolledSubjectEntity Xmrkva01IJC = new()
    {
        Id = Guid.Parse("07671bf7-6690-42bc-8010-a94f66725f08"),
        SubjectId = SubjectSeeds.IJC.Id,
        StudentId = StudentSeeds.Xmrkva01.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IJC,
        Student = StudentSeeds.Xmrkva01,
        Points = 71,
        Mark = Mark.C
    };

    public static readonly EnrolledSubjectEntity Xmrkva01IFJ = new()
    {
        Id = Guid.Parse("7f61e4ce-692d-4791-8609-c4c61c18988d"),
        SubjectId = SubjectSeeds.IFJ.Id,
        StudentId = StudentSeeds.Xmrkva01.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IFJ,
        Student = StudentSeeds.Xmrkva01,
        Points = 97,
        Mark = Mark.A
    };

    public static readonly EnrolledSubjectEntity Xmrkva01IDS = new()
    {
        Id = Guid.Parse("86ff751e-213a-42a0-9b3b-e52b20e11c98"),
        SubjectId = SubjectSeeds.IDS.Id,
        StudentId = StudentSeeds.Xmrkva01.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IDS,
        Student = StudentSeeds.Xmrkva01,
        Points = 12,
        Mark = Mark.None
    };

    public static readonly EnrolledSubjectEntity Xmrkva01IMA = new()
    {
        Id = Guid.Parse("0f570c7e-3c81-4be0-9dc0-1e28ba71b916"),
        SubjectId = SubjectSeeds.IMA.Id,
        StudentId = StudentSeeds.Xmrkva01.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IMA,
        Student = StudentSeeds.Xmrkva01,
        Points = 18,
        Mark = Mark.None
    };

    public static readonly EnrolledSubjectEntity Xmrkva01ICS = new()
    {
        Id = Guid.Parse("28e5dfaa-045a-4f04-a371-5067b0d1c06f"),
        SubjectId = SubjectSeeds.ICS.Id,
        StudentId = StudentSeeds.Xmrkva01.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.ICS,
        Student = StudentSeeds.Xmrkva01,
        Points = 100,
        Mark = Mark.A
    };

    public static readonly EnrolledSubjectEntity Xkolar51IDS = new()
    {
        Id = Guid.Parse("269b4a0e-f07f-45ce-8586-81761dd599e0"),
        SubjectId = SubjectSeeds.IDS.Id,
        StudentId = StudentSeeds.Xkolar51.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IDS,
        Student = StudentSeeds.Xkolar51,
        Points = 10,
        Mark = Mark.None
    };

    public static readonly EnrolledSubjectEntity Xjozef01IIS = new()
    {
        Id = Guid.Parse("f6d72f38-f33e-4246-942a-ced94ba8b485"),
        SubjectId = SubjectSeeds.IIS.Id,
        StudentId = StudentSeeds.Xjozef01.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IIS,
        Student = StudentSeeds.Xjozef01,
        Points = 0,
        Mark = Mark.None
    };

    public static readonly EnrolledSubjectEntity Xstude00IDS = new()
    {
        Id = Guid.Parse("36f96027-6267-4342-ac10-f8d51c41c610"),
        SubjectId = SubjectSeeds.IDS.Id,
        StudentId = StudentSeeds.Xstude00.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IDS,
        Student = StudentSeeds.Xstude00,
        Points = 0,
        Mark = Mark.None
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<EnrolledSubjectEntity>().HasData(
            Xplagi00IFJ with { Subject = null!, Student = null! },
            Xmrkva01IJC with { Subject = null!, Student = null! },
            Xmrkva01IFJ with { Subject = null!, Student = null! },
            Xmrkva01IDS with { Subject = null!, Student = null! },
            Xmrkva01IMA with { Subject = null!, Student = null! },
            Xmrkva01ICS with { Subject = null!, Student = null! },
            Xkolar51IDS with { Subject = null!, Student = null! },
            Xjozef01IIS with { Subject = null!, Student = null! },
            Xstude00IDS with { Subject = null!, Student = null! }
        );
}
