namespace project.DAL.Entities
{
    public interface IUserEntity : IEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Image { get; set; }

    }

}