using project.DAL.Enums;

namespace project.DAL.Entities;

public record StudentEntity : IUserEntity
{
    public required Guid Id { get; set; }
    public required string Email { get; set; }
    public TitleBefore TitleBefore { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public TitleAfter TitleAfter { get; set; }
    public string? Image { get; set; }
    public ICollection<SubjectEntity> TeachingSubjects { get; init; } = new List<SubjectEntity>();
}
