using project.DAL.Entities;

namespace project.DAL.Mappers;

public class ActivityEntityMapper : IEntityMapper<ActivityEntity>
{
    public void MapToExistingEntity(ActivityEntity existingEntity, ActivityEntity newEntity)
    {
        existingEntity.Start = newEntity.Start;
        existingEntity.End = newEntity.End;
        existingEntity.Place = newEntity.Place;
        existingEntity.ActivityType = newEntity.ActivityType;
        existingEntity.Description = newEntity.Description;
        existingEntity.SubjectId = newEntity.SubjectId;
        existingEntity.EvaluationId = newEntity.EvaluationId;
    }
}
