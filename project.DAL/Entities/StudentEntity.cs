namespace project.DAL.Entities
{
    public record StudentEntity : IUserEntity
    {
        public required Guid Id { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public int Grade { get; set; }
        public Uri? Image { get; set; }

        public ICollection<EnrolledSubjectEntity> EnrolledSubjects { get; init; } =
            new List<EnrolledSubjectEntity>();

        public ICollection<RegisteredActivitiesEntity> RegisteredActivities { get; init; } =
            new List<RegisteredActivitiesEntity>();

        public ICollection<EvaluationEntity> Evaluations { get; init; } = new List<EvaluationEntity>();
    }
}
