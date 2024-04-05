using project.DAL.Enums;

namespace project.BL.Models;

public record EnrolledSubjectsListModel : ModelBase
{
    public required string SubjectName { get; set; }
    public required int Points { get; set; }
    public required Mark Mark { get; set; }

    public static EnrolledSubjectsListModel Empty => new()
    {
        SubjectName = string.Empty,
        Points = 0,
        Mark = Mark.None
    };
}
