using project.DAL.Enums;

namespace project.DAL.Entities
{
    public record ActivityEntity : IEntity
    {
        public required Guid Id { get; set; }
        public required DateTime Start { get; set; }
        public required DateTime End { get; set; }
        public required Place Place { get; set; }
        public required ActivityType ActivityType { get; set; }
        public string? Description { get; set; }
        public required Guid SubjectId { get; set; }
        public required Guid EvaluationId { get; set; }

        public required SubjectEntity Subject { get; init; }
        public EvaluationEntity? Evaluation { get; init; }
    }
}

