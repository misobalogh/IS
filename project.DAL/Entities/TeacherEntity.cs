﻿using project.DAL.Enums;

namespace project.DAL.Entities
{
    public record TeacherEntity : IUserEntity
    {
        public required Guid Id { get; set; }
        public required string Email { get; set; }
        public TitleBefore? TitleBefore { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public TitleAfter? TitleAfter { get; set; }
        public required string Password { get; set; }
        public Uri? Image { get; set; }

        public ICollection<TeachingSubjectsEntity> Subjects { get; init; } = new List<TeachingSubjectsEntity>();
    }
}
