using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace project.DAL.Seeds;

public static class TeacherSeeds
{
    public static readonly TeacherEntity Chrobak = new()
    {
        Id = Guid.Parse("acce5c7a-2266-43ef-921b-c6b5e4c1390c"),
        FirstName = "Roman",
        LastName = "Chrobak",
        Email = "chrobak@email.com",
        Password = "asdm9m1dm901",
    };
    
    public static readonly TeacherEntity Lienka = new()
    {
        Id = Guid.Parse("45083d2e-a91f-43a3-9ff4-a1d48a30e06f"),
        FirstName = "Lenka",
        LastName = "Lienka",
        Email = "lienka@email.com",
        Password = "#ASDld10981"
    };
    
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<TeacherEntity>().HasData(
            Chrobak,
            Lienka
        );
}
