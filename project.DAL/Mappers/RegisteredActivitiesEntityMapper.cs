using project.DAL.Entities;

namespace project.DAL.Mappers;

public class RegisteredActivitiesEntityMapper : IEntityMapper<RegisteredActivitiesEntity>
{
    public void MapToExistingEntity(RegisteredActivitiesEntity existingEntity, RegisteredActivitiesEntity newEntity)
    {
        existingEntity.StudentId = newEntity.StudentId;
        existingEntity.ActivityId = newEntity.ActivityId;
    }
}
