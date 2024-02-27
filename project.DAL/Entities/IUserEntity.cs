namespace project.DAL.Entities
{
    public interface IUserEntity : IEntity
    {
        public required Guid Id { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Image { get; set; }

    }

}