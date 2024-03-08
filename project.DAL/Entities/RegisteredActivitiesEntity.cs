namespace project.DAL.Entities
{
    public record RegisteredActivitiesEntity: IEntity
    {
        public required Guid Id { get; set; }
        public required Guid StudentId { get; set; }
        public required Guid ActivityId { get; set; }

        public required StudentEntity Student { get; init; }
        public required ActivityEntity Activity { get; init; }

    }
}
