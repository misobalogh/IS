namespace project.DAL.Entities
{
    public record TeachingSubjectsEntity : IUsersSubjectEntity
    {
        public required Guid Id { get; set; }
        public required Guid SubjectId { get; set; }
        public required Guid TeacherId { get; set; }
        public required SubjectEntity Subject { get; init; }
        public required TeacherEntity Teacher { get; init; }
        public required DateTime Year { get; set; }
    }
}
