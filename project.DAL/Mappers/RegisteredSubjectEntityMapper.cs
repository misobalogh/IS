using project.DAL.Entities;

namespace project.DAL.Mappers;

public class RegisteredSubjectEntityMapper : IEntityMapper<RegisteredSubjectEntity>
{
    public void MapToExistingEntity(RegisteredSubjectEntity existingEntity, RegisteredSubjectEntity newEntity)
    {
        existingEntity.Year = newEntity.Year;
        existingEntity.StudentId = newEntity.StudentId;
        existingEntity.SubjectId = newEntity.SubjectId;
    }
}
