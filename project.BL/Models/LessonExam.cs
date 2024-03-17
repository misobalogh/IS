namespace project.BL.Models;

public record LessonExam : ModelBase
{
    public required Guid ExamId { get; set; }
    public required string NameOfExam { get; set; }
    public required double Points { get; set; }
    public string? Description { get; set; }

    public static LessonExam Empty => new()
    {
        ExamId = Guid.Empty,
        NameOfExam = string.Empty,
        Points = 0,
    };
}
