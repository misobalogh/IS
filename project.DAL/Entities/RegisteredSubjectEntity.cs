namespace project.DAL.Entities
{
    public record RegisteredSubjectEntity : IUsersSubjectEntity
    {
        public required Guid Id { get; set; }
        public required DateTime Year { get; set; }
        public required Guid StudentId { get; set; }
        public required Guid SubjectId { get; set; }
        
        public required SubjectEntity Subject { get; init; }
        public required StudentEntity Student { get; init; }
        
    }
}
