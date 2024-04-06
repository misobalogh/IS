using System.Collections.ObjectModel;

namespace project.BL.Models;

public record EvaluationModel : ModelBase
{
    public required int Points { get; set; }
    public string? Note { get; set; }
    public required Guid StudentId { get; set; }
    //TODO: maybe StudentName
    public static EvaluationModel Empty => new()
    {
        Points = 0,
        StudentId = Guid.Empty,
        Id = Guid.Empty,
        Note = String.Empty
    };
}
