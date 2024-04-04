namespace project.DAL.Entities
{
    public interface IUserEntity : IEntity
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Uri? Image { get; set; }
        string Login { get; set; }
        string Password { get; set; }
    }

}
