using project.DAL.Enums;

namespace project.BL.Models;

public record ActivityModel : ModelBase
{
    public required Guid ActivityModelId { get; set; }
    public required string ActivityName { get; set; }
    public required UserModel Teacher { get; set; }
    public required Place Room { get; set; }
    public required int Capacity { get; set; }
    public required int MaxPoints { get; set; }

    public static ActivityModel Empty => new()
    {
        ActivityModelId = Guid.Empty,
        Id = Guid.Empty,
        ActivityName = string.Empty,
        Teacher = UserModel.Empty,
        Room = Place.None,
        Capacity = 0,
        MaxPoints = 0
    };
}
