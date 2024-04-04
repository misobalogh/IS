using project.DAL.Entities;

namespace project.DAL.Mappers;

public class RegisteredSubjectEntityMapper : IEntityMapper<EnrolledSubjectEntity>
{
    public void MapToExistingEntity(EnrolledSubjectEntity existingEntity, EnrolledSubjectEntity newEntity)
    {
        existingEntity.Year = newEntity.Year;
        existingEntity.StudentId = newEntity.StudentId;
        existingEntity.SubjectId = newEntity.SubjectId;
    }
}
