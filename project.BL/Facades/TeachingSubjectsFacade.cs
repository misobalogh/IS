using System.Reflection;
using project.BL.Mappers;
using project.BL.Models;
using project.DAL.Entities;
using project.DAL.Mappers;
using project.DAL.Repositories;
using project.DAL.UnitOfWork;

namespace project.BL.Facades;

public class TeachingSubjectsFacade(IUnitOfWorkFactory unitOfWorkFactory, TeachingSubjectsModelMapper teachingSubjectsModelMapper)
    : FacadeBase<TeachingSubjectsEntity, TeachingSubjectsListModel, TeachingSubjectsModel, TeachingSubjectsEntityMapper>(unitOfWorkFactory, teachingSubjectsModelMapper), ITeachingSubjectsFacade
{
    public async Task SaveAsync(TeachingSubjectsListModel model, Guid teacherId)
    {
        TeachingSubjectsEntity entity = teachingSubjectsModelMapper.MapToEntity(model, teacherId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<TeachingSubjectsEntity> repository =
            uow.GetRepository<TeachingSubjectsEntity, TeachingSubjectsEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await uow.CommitAsync();
        }
    }
    public async Task SaveAsync(TeachingSubjectsModel model, Guid teacherId)
    {
        TeachingSubjectsEntity entity = teachingSubjectsModelMapper.MapToEntity(model, teacherId);

        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        IRepository<TeachingSubjectsEntity> repository =
            unitOfWork.GetRepository<TeachingSubjectsEntity, TeachingSubjectsEntityMapper>();

        await repository.InsertAsync(entity);
        await unitOfWork.CommitAsync();
    }  
}
