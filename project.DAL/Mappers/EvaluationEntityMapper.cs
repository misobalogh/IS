using project.DAL.Entities;

namespace project.DAL.Mappers;

public class EvaluationEntityMapper : IEntityMapper<EvaluationEntity>
{
    public void MapToExistingEntity(EvaluationEntity existingEntity, EvaluationEntity newEntity)
    {
        existingEntity.Id = newEntity.Id;
        existingEntity.Points = newEntity.Points;
        existingEntity.Note = newEntity.Note;
        existingEntity.StudentId = newEntity.Id;
    }
}
