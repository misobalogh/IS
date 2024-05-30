using project.DAL.Enums;

namespace project.BL.Models;

public record TeachingSubjectsModel : ModelBase
{
    public required Guid SubjectId { get; set; }
    public required DateTime Year { get; set; }


    public static TeachingSubjectsModel Empty => new()
    {
        SubjectId = Guid.Empty,
        Year = DateTime.Now
    };
}
