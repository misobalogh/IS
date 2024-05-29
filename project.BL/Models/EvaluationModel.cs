using System.Collections.ObjectModel;

namespace project.BL.Models;

public record EvaluationModel : ModelBase
{
    public required int Points { get; set; }
    public string? Note { get; set; }
    public required Guid StudentId { get; set; }
    public required Guid ActivityId { get; set; }
    public required string StudentFirstName { get; set; }
    public required string StudentLastName { get; set; }
    public static EvaluationModel Empty => new()
    {
        Points = 0,
        StudentId = Guid.Empty,
        StudentFirstName = string.Empty,
        StudentLastName = string.Empty,
        Id = Guid.Empty,
        Note = string.Empty,
        ActivityId = Guid.Empty
    };
}
