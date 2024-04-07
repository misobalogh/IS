using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace project.Common.Tests.Seeds;

public static class StudentSeeds
{
    public static readonly StudentEntity Xplagi00 = new()
    {
        Id = Guid.Parse("789a3e3a-0d52-4cc6-b5b2-6e5819594300"),
        FirstName = "John",
        LastName = "Doe",
        Email = "xplagi00@email.com",
        Password = "113dDSas6H"
        
    };
    
    public static readonly StudentEntity Xmrkva01 = new()
    {
        Id = Guid.Parse("86b94a78-c900-473d-9e57-f1b93cc98190"),
        FirstName = "Jack",
        LastName = "Mrkva",
        Email = "xmrkva01@email.com",
        Password = "9n1d8as"
        
    };
    
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<StudentEntity>().HasData(
            Xplagi00,
            Xmrkva01
        );
}
