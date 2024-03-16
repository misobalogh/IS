using project.DAL.Entities;

namespace project.DAL.Mappers;

public class TeacherEntityMapper : IEntityMapper<TeacherEntity>
{
    public void MapToExistingEntity(TeacherEntity existingEntity, TeacherEntity newEntity)
    {
        existingEntity.Email = newEntity.Email;
        existingEntity.TitleBefore = newEntity.TitleBefore;
        existingEntity.FirstName = newEntity.FirstName;
        existingEntity.LastName = newEntity.LastName;
        existingEntity.TitleAfter = newEntity.TitleAfter;
        existingEntity.Image = newEntity.Image;
    }
}
