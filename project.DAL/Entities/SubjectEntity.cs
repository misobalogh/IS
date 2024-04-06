using project.DAL.Enums;

namespace project.DAL.Entities
{
    public record SubjectEntity : IEntity
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Tag { get; set; }
        public Semester Semester { get; set; }

    }
}
