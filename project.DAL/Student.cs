namespace project.DAL
{
    public record Student: IEntity
    {
        public required Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string? Image { get; set; }
        
    }
}


public record Subject : IEntity 
{

    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Tag { get; set; }

}
