using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace project.DAL.Seeds;

public static class TeachingSubjectsSeeds
{
    public static readonly TeachingSubjectsEntity ChrobakIJC = new()
    {
        Id = Guid.Parse("8c76cfde-f278-459b-8354-15f9c6dc68e1"),
        SubjectId = SubjectSeeds.IJC.Id,
        TeacherId = TeacherSeeds.Chrobak.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IJC,
        Teacher = TeacherSeeds.Chrobak
    };
    
    public static readonly TeachingSubjectsEntity LienkaIFJ = new()
    {
        Id = Guid.Parse("323f2144-de33-4185-b20e-53764ff39956"),
        SubjectId = SubjectSeeds.IFJ.Id,
        TeacherId = TeacherSeeds.Lienka.Id,
        Year = DateTime.Today,
        Subject = SubjectSeeds.IFJ,
        Teacher = TeacherSeeds.Lienka
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<TeachingSubjectsEntity>().HasData(
            ChrobakIJC with { Subject = null!, Teacher = null! },
            LienkaIFJ with { Subject = null!, Teacher = null! }
        );
}
