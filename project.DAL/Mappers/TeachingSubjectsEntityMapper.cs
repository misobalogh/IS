using project.DAL.Entities;

namespace project.DAL.Mappers;

public class TeachingSubjectsEntityMapper : IEntityMapper<TeachingSubjectsEntity>
{
    public void MapToExistingEntity(TeachingSubjectsEntity existingEntity, TeachingSubjectsEntity newEntity)
    {
        existingEntity.Year = newEntity.Year;
        existingEntity.SubjectId = newEntity.SubjectId;
        existingEntity.TeacherId = newEntity.TeacherId;
    }
}
