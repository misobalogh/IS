using project.DAL.Enums;

namespace project.BL.Models;

public record ActivityListModel : ModelBase
{
    public required Guid SubjectId { get; set; }
    public required string Name { get; set; }
    public required string SubjectName { get; set; }
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public required Room Room { get; set; }
    public required double Points { get; set; }
    public required int Capacity { get; set; }
    public required string Tag { get; set; }
    public required ActivityType ActivityType { get; set; }
    public required string TeacherName { get; set; }

    public static ActivityListModel Empty => new()
    {
        Id = Guid.Empty,
        SubjectId = Guid.Empty,
        Start = DateTime.Now,
        End = DateTime.Now,
        Name = string.Empty,
        SubjectName = string.Empty,
        Room = Room.None,
        Capacity = 0,
        Tag = string.Empty,
        ActivityType = ActivityType.None,
        TeacherName = string.Empty,
        Points = 0
    };
}
