namespace project.DAL.Entities
{
    public record EvaluationEntity : IEntity
    {
        public required Guid Id { get; set; }   
        public required int Points { get; set; }
        public string? Note { get; set; }
        public required ActivityEntity Activity { get; init; }
        public required StudentEntity Student { get; init; }

    }
}

