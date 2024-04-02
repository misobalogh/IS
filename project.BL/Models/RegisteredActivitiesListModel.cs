using project.DAL.Enums;

namespace project.BL.Models;

public record RegisteredActivitiesListModel : ModelBase
{
    public required Guid ActivityId { get; set; }
    public required bool IsRegistered { get; set; }

    public static RegisteredActivitiesListModel Empty => new()
    {
        Id = Guid.Empty,
        ActivityId = Guid.Empty,
        IsRegistered = false
    };
}
