using project.DAL.Enums;

namespace project.DAL.Entities
{
    public record ActivityEntity : IEntity
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required DateTime Start { get; set; }
        public required DateTime End { get; set; }
        public required Room Room { get; set; }
        public required int Capacity { get; set; }
        public required ActivityType ActivityType { get; set; }
        public string? Description { get; set; }
        public required Guid SubjectId { get; set; }
        public required Guid EvaluationId { get; set; }
        public required Guid TeacherId { get; set; }
        // MaxPoints == null means this activity has no points (e.g. lecture)
        public required int? MaxPoints { get; set; }
        // How many points student received
        public required double Points { get; set; }

        public required SubjectEntity Subject { get; init; }
        //TODO: ma to byt tady nebo activity v Evaluation?
        public EvaluationEntity? Evaluation { get; init; }
        public required TeacherEntity Teacher { get; init; }
    }
}

