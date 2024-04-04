using project.DAL.Enums;

namespace project.BL.Models;

public record RegisteredActivitiesListModel : ModelBase
{
    public required Guid ActivityId { get; set; }
    public required string ActivityName { get; set; }
    public required SubjectModel Subject { get; set; }
    public required bool IsRegistered { get; set; }

    public static RegisteredActivitiesListModel Empty => new()
    {
        Id = Guid.Empty,
        ActivityId = Guid.Empty,
        ActivityName = string.Empty,
        Subject = SubjectModel.Empty,
        IsRegistered = false
    };
}
