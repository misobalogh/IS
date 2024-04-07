namespace project.BL.Models;

public record RegisteredActivitiesModel : ModelBase
{
    public required Guid ActivityId { get; set; }
    public required string ActivityName { get; set; }

    public static RegisteredActivitiesModel Empty => new()
    {
        Id = Guid.Empty,
        ActivityId = Guid.Empty,
        ActivityName = string.Empty
    };
}
