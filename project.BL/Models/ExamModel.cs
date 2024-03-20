using project.DAL.Enums;

namespace project.BL.Models;

public record ExamModel : ModelBase
{
    public required Guid ExamModelId { get; set; }
    public required SubjectModel Subject { get; set; }
    public required string ExamName { get; set; }
    public required UserModel Teacher { get; set; }
    public required Place Room { get; set; }
    public required int Capacity { get; set; }
    public bool isRegistered { get; set; }

    public static ExamModel Empty => new()
    {
        ExamModelId = Guid.Empty,
        Id = Guid.Empty,
        Subject = SubjectModel.Empty,
        ExamName = string.Empty,
        Teacher = UserModel.Empty,
        Room = Place.None,
        Capacity = 0
    };
}
