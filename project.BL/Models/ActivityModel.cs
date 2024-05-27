using project.DAL.Enums;

namespace project.BL.Models;

public record ActivityModel : ModelBase
{
    public required Guid SubjectId { get; set; }
    public required string SubjectName { get; set; }
    public required string Name { get; set; }
    public required ActivityType ActivityType { get; set; }
    public required string TeacherName { get; set; }
    public required Guid TeacherId { get; set; }
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public required Room Room { get; set; }
    public required int? Capacity { get; set; }
    // MaxPoints == null means this activity has no points (e.g. lecture)
    public required int? MaxPoints { get; set; }
    // How many points student received
    public static ActivityModel Empty => new()
    {
        Id = Guid.Empty,
        SubjectId = Guid.Empty,
        Start = DateTime.Now,
        End = DateTime.Now,
        Name = string.Empty,
        TeacherName = string.Empty,
        SubjectName = string.Empty,
        ActivityType = ActivityType.None,
        Room = Room.None,
        Capacity = null,
        MaxPoints = null,
        TeacherId = Guid.Empty,
    };
}
