using project.DAL.Enums;

namespace project.BL.Models;

public record UserModel : ModelBase
{
    public Guid UserId { get; set; }
    public TitleBefore TitleBefore { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public TitleAfter TitleAfter { get; set; }
    public Role Role { get; set; }

    public static UserModel Empty => new()
    {
        UserId = Guid.Empty,
        Id = Guid.Empty, 
        FirstName = string.Empty, 
        LastName = string.Empty,
    };
}
