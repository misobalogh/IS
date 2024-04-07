using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using project.DAL.Enums;

namespace project.Common.Tests.Seeds;

public static class RegisteredSubjectsSeeds
{
    public static readonly EnrolledSubjectEntity Xplagi00IFJ = new()
    {
        Id = Guid.Parse("371a5d4a-c60d-4e45-b3a1-db2bca96b240"),
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
        Id = Guid.Parse("07671bf7-6690-42bc-8010-a94f66725f00"),
        SubjectId = SubjectSeeds.IJC.Id,
        StudentId = StudentSeeds.Xmrkva01.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IJC,
        Student = StudentSeeds.Xmrkva01,
        Points = 0,
        Mark = Mark.None
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<EnrolledSubjectEntity>().HasData(
            Xplagi00IFJ with { Subject = null!, Student = null! },
            Xmrkva01IJC with { Subject = null!, Student = null! }
        );
}
