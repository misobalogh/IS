using project.DAL.Enums;

namespace project.BL.Models;

public record ActivityModel : ModelBase
{
    public required string ActivityName { get; set; }
    public required TeacherModel Teacher { get; set; }
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public required Room Room { get; set; }
    public required int Capacity { get; set; }
    // MaxPoints == null means this activity has no points (e.g. lecture)
    public required int? MaxPoints { get; set; }
    // How many points student received
    public required double Points { get; set; }

    public static ActivityModel Empty => new()
    {
        ActivityModelId = Guid.Empty,
        Id = Guid.Empty,
        Start = DateTime.Now,
        End = DateTime.Now,
        ActivityName = string.Empty,
        Teacher = TeacherModel.Empty,
        Room = Room.None,
        Capacity = 0,
        MaxPoints = 0,
        Points = 0
    };
}
