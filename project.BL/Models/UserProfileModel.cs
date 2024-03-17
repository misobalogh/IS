using System.Collections.ObjectModel;
using project.DAL.Enums;

namespace project.BL.Models;

public record UserProfileModel : ModelBase
{
    public required Guid UserId { get; set; }
    public required string Username { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public ObservableCollection<SubjectModel> SubjectInformation { get; set; } = new();
    public Uri? PhotoUrl { get; set; }

    //TODO: bude změna hesla?

    public static UserProfileModel Empty => new()
    {
        UserId = Guid.Empty,
        Id = Guid.Empty,
        Username = string.Empty,
        FirstName = string.Empty,
        LastName = string.Empty,
        Email = string.Empty,
        Role = Role.None,
        PhotoUrl = string.Empty
    };
}

