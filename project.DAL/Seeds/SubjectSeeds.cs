using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace project.DAL.Seeds;

public static class SubjectSeeds
{
    public static readonly SubjectEntity IJC = new()
    {
        Id = Guid.Parse("6180b520-6119-4303-8496-ed568d684209"),
        Name = "Jazyk C",
        Tag = "IJC"
    };
    
    public static readonly SubjectEntity IFJ = new()
    {
        Id = Guid.Parse("e8b9f519-c2df-4c4c-8ce3-8dbfcf9557d4"),
        Name = "Formalitka Jednoducha",
        Tag = "IFJ"
    };

    public static readonly SubjectEntity IDS = new()
    {
        Id = Guid.Parse("d7e6fb03-6425-49f6-8667-6ecf862a6fcc"),
        Name = "Databazove Systemy",
        Tag = "IDS"
    };

    public static readonly SubjectEntity IIS = new()
    {
        Id = Guid.Parse("46e9b926-7e8d-4edc-a0c7-707dd7f26fac"),
        Name = "Informacne Systemy",
        Tag = "IIS"
    };

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<SubjectEntity>().HasData(
            IJC,
            IFJ,
            IDS,
            IIS
        );
}
