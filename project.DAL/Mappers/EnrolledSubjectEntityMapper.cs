using project.DAL.Entities;

namespace project.DAL.Mappers;

public class EnrolledSubjectEntityMapper : IEntityMapper<EnrolledSubjectEntity>
{
    //TODO: check
    public void MapToExistingEntity(EnrolledSubjectEntity existingEntity, EnrolledSubjectEntity newEntity)
    {
        existingEntity.Mark = newEntity.Mark;
        existingEntity.Points = newEntity.Points;
        existingEntity.StudentId = newEntity.StudentId;
        existingEntity.SubjectId = newEntity.SubjectId;
        existingEntity.Year = newEntity.Year;
    }
}
