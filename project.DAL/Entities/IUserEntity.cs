namespace project.DAL.Entities
{
    public interface IUserEntity : IEntity
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string? Image { get; set; }

    }

}
