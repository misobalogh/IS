namespace project.DAL.Entities
{
    public record StudentEntity: IUserEntity
    {
        public required Guid Id { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Image { get; set; }
        public ICollection<SubjectEntity> EnrolledSubjects { get; init; } = [];

    }
}




