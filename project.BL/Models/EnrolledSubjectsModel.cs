using project.DAL.Enums;

namespace project.BL.Models;

public record EnrolledSubjectsModel : ModelBase
{
    public required Guid SubjectId { get; set; }
    public required string SubjectName { get; set; }
    public required int Points { get; set; }
    public required Mark Mark { get; set; }
    public required DateTime Year { get; set; }
    public required Guid StudentId { get; set; }

    public static EnrolledSubjectsModel Empty => new()
    {
        SubjectId = Guid.Empty,
        SubjectName = string.Empty,
        Points = 0,
        Mark = Mark.None,
        Year = DateTime.Now,
        StudentId = Guid.Empty,
    };
}
