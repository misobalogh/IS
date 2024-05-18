using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace project.DAL.Seeds;

public static class StudentSeeds
{
    public static readonly StudentEntity Xplagi00 = new()
    {
        Id = Guid.Parse("789a3e3a-0d52-4cc6-b5b2-6e5819594380"),
        FirstName = "John",
        LastName = "Doe",
        Email = "xplagi00@email.com",
        Password = "113dDSas6H",
        Image = null
        
    };
    
    public static readonly StudentEntity Xmrkva01 = new()
    {
        Id = Guid.Parse("86b94a78-c900-473d-9e57-f1b93cc9819f"),
        FirstName = "Jack",
        LastName = "Mrkva",
        Email = "xmrkva01@email.com",
        Password = "9n1d8as",
        Image = new Uri("https://images.unsplash.com/photo-1500648767791-00dcc994a43e?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D")
    };

    public static readonly StudentEntity Xkolar51 = new()
    {
        Id = Guid.Parse("214af588-69ab-43b4-baa1-4973b1a6eda9"),
        FirstName = "Karel",
        LastName = "Kolar",
        Email = "xkolar51@email.com",
        Password = "random_pass",
        Image = null
    };

    public static readonly StudentEntity Xjozef01 = new()
    {
        Id = Guid.Parse("962dbc44-3ec6-41f1-9b27-ddd06016f0c6"),
        FirstName = "Erik",
        LastName = "Jozefcak",
        Email = "xjozef01@email.com",
        Password = "very_hard_123",
        Image = null
    };

    public static readonly StudentEntity Xstude00 = new()
    {
        Id = Guid.Parse("44ca97c3-1a70-42dd-9e37-0e3c74ef7301"),
        FirstName = "Eva",
        LastName = "Studena",
        Email = "xstude00@email.com",
        Password = "password123",
        Image = null
    };
    
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<StudentEntity>().HasData(
            Xplagi00,
            Xmrkva01,
            Xkolar51,
            Xjozef01,
            Xstude00
        );
}
