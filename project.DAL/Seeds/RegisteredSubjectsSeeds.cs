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
        Points = 0,
        Mark = Mark.None
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
            Xkolar51IDS with { Subject = null!, Student = null! },
            Xjozef01IIS with { Subject = null!, Student = null! },
            Xstude00IDS with { Subject = null!, Student = null! }
        );
}
