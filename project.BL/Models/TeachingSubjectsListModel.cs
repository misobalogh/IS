using project.DAL.Enums;

namespace project.BL.Models;

public record TeachingSubjectsListModel : ModelBase
{
    public required Guid SubjectId { get; set; }
    public required DateTime Year { get; set; }


    public static TeachingSubjectsListModel Empty => new()
    {
        SubjectId = Guid.Empty,
        Year = DateTime.Now
    };
}
