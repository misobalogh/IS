namespace project.DAL.Entities
{
    public record EvaluationEntity : IEntity
    {
        public required Guid Id;
        public required int Points;
        public string Note;
        public required ActivityEntity Activity;
        public required StudentEntity Student; 

    }
}

