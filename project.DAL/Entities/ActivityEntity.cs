using System;
using project.DAL.Enums;

namespace project.DAL.Entities
{
    public record ActivityEntity : IEntity
    {
        public required Guid Id;
        public required DateTime Start;
        public required DateTime End;
        public required Place Place;
        public required ActivityType ActivityType;
        public string Description;
        public required SubjectEntity Subject;
        public EvaluationEntity Evaluation;

    }
}

