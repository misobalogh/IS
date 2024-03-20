using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.BL.Models;

public record RegisterUserModel : ModelBase
{
    public required Guid RegisterUserId { get; set; }
    public required string UserName { get; set;}
    public required string Name { get; set;}
    public required string Surname { get; set;}
    public required string Email { get; set;}
    public required string Password { get; set;}

    public static RegisterUserModel Empty => new()
    {
        RegisterUserId = Guid.Empty,
        Id = Guid.Empty,
        UserName = string.Empty,
        Name = string.Empty,
        Surname = string.Empty,
        Email = string.Empty,
        Password = string.Empty,
    };
}

