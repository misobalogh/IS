namespace project.BL.Models;

using System.Collections.ObjectModel;

public record EvaluationListModel : ModelBase
{
    public required int Points { get; set; }
    public required Guid StudentId { get; set; }
    public required Guid ActivityId { get; set; }
    public required string StudentFirstName { get; set; }
    public required string StudentLastName { get; set; }
    public static EvaluationListModel Empty => new()
    {
        Points = 0,
        StudentId = Guid.Empty,
        StudentFirstName = string.Empty,
        StudentLastName = string.Empty,
        Id = Guid.Empty,
        ActivityId = Guid.Empty
    };
}
