using project.DAL.Enums;

namespace project.BL.Models;

public record ExamModel : ModelBase
{
    public required SubjectModel Subject { get; set; }
    public required string ExamName { get; set; }
    public required UserModel Teacher { get; set; }
    public required Place Room { get; set; }
    public required int Capacity { get; set; }
}
