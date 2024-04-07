using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace project.Common.Tests.Seeds;

public static class TeacherSeeds
{
    public static readonly TeacherEntity Chrobak = new()
    {
        Id = Guid.Parse("acce5c7a-2266-43ef-921b-c6b5e4c13900"),
        FirstName = "Roman",
        LastName = "Chrobak",
        Email = "chrobak@email.com",
        Password = "asdm9m1dm901",
    };
    
    public static readonly TeacherEntity Lienka = new()
    {
        Id = Guid.Parse("45083d2e-a91f-43a3-9ff4-a1d48a30e060"),
        FirstName = "Lenka",
        LastName = "Lienka",
        Email = "lienka@email.com",
        Password = "#ASDld10981"
    };

    public static TeacherEntity TeacherEntity = new()
    {
        Email = "test@email.cz",
        FirstName = "Honza",
        LastName = "Novák",
        Id = Guid.Parse(input: "60b189ce-34fe-4260-b36b-6adefa4e0f2d"),
        Password = "secret_hard_password."
    };


    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<TeacherEntity>().HasData(
            Chrobak,
            Lienka,
            TeacherEntity
        );
}
