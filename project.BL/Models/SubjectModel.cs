using project.DAL.Enums;

namespace project.BL.Models;

public record SubjectModel : ModelBase
{
    public required Guid SubjectId { get; set; }
    public required string SubjectName { get; set; }
    public required string SubjectTag { get; set; }
    public required double TotalPoints { get; set; }
    public string? SubjectDescription { get; set;}
    public string? LessonPlan { get; set;}
    public Marks Mark { get; set; }
    public string? ExercisePlan { get; set;}
    public string? ProjectInfo { get; set;}

    public static SubjectModel Empty => new()
    {
        SubjectId = Guid.Empty,
        SubjectName = string.Empty,
        SubjectTag = string.Empty,
        TotalPoints = 0,
    };
};
