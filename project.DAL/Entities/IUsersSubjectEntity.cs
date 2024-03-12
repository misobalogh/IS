namespace project.DAL.Entities
{
    public interface IUsersSubjectEntity : IEntity
    {
        Guid SubjectId { get; set; }

        SubjectEntity Subject { get; init; }
    }
}
