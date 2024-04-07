using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace project.Common.Tests.Seeds;

public static class TeachingSubjectsSeeds
{
    public static readonly TeachingSubjectsEntity ChrobakIJC = new()
    {
        Id = Guid.Parse("8c76cfde-f278-459b-8354-15f9c6dc68e0"),
        SubjectId = SubjectSeeds.IJC.Id,
        TeacherId = TeacherSeeds.Chrobak.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IJC,
        Teacher = TeacherSeeds.Chrobak
    };
    
    public static readonly TeachingSubjectsEntity LienkaIFJ = new()
    {
        Id = Guid.Parse("323f2144-de33-4185-b20e-53764ff39950"),
        SubjectId = SubjectSeeds.IFJ.Id,
        TeacherId = TeacherSeeds.Lienka.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IFJ,
        Teacher = TeacherSeeds.Lienka
    };
    
    public static TeachingSubjectsEntity TeacherEntity = new()
    {
        Id = Guid.Parse(input: "60b189ce-34fe-4260-b36b-6adefa4e1f2d"),
        SubjectId = SubjectSeeds.IFJ.Id,
        TeacherId = TeacherSeeds.TeacherEntity.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IFJ,
        Teacher = TeacherSeeds.TeacherEntity
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<TeachingSubjectsEntity>().HasData(
            ChrobakIJC with { Subject = null!, Teacher = null! },
            LienkaIFJ with { Subject = null!, Teacher = null! }
        );
}
