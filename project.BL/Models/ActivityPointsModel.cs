namespace project.BL.Models;

public record ActivityPointsModel : ModelBase
{
    public required Guid ExamId { get; set; }
    public required double Points { get; set; }

    
    public required ActivityModel Activity { get; set; }

    public static ActivityPointsModel Empty => new()
    {
        ExamId = Guid.Empty,
        Points = 0,
        Activity = ActivityModel.Empty
    };
}
