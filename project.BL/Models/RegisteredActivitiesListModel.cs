using project.DAL.Enums;

namespace project.BL.Models;

public record RegisteredActivitiesListModel : ModelBase
{
    public required Guid ActivityId { get; set; }
    public required string ActivityName { get; set; }
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public required Room Room { get; set; }

    public static RegisteredActivitiesListModel Empty => new()
    {
        Id = Guid.Empty,
        ActivityId = Guid.Empty,
        Start = DateTime.Now,
        End = DateTime.Now,
        Room = Room.None,
        ActivityName = string.Empty
    };
}
