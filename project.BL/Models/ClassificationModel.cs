namespace project.BL.Models;

public record StrudentClassificationModel : ModelBase
{
    public required string SemesterName { get; set; } 
    public required SubjectModel Subject { get; set; }

    public static StrudentClassificationModel Empty => new()
    {
        SemesterName = string.Empty,
        Subject = SubjectModel.Empty,
    };
}
