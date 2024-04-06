using project.DAL.Enums;

namespace project.DAL.Entities
{
    public record EnrolledSubjectEntity : IUsersSubjectEntity
    {
        public required Guid Id { get; set; }
        public required DateTime Year { get; set; }
        public required Guid StudentId { get; set; }
        public required Guid SubjectId { get; set; }
        public required int Points { get; set; }
        public required Mark Mark { get; set; }
        
        public required SubjectEntity Subject { get; init; }
        public required StudentEntity Student { get; init; }
        
    }
}
