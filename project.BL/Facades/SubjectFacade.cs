using project.BL.Mappers;
using project.BL.Models;
using project.DAL.Entities;
using project.DAL.Mappers;
using project.DAL.Repositories;
using project.DAL.UnitOfWork;

namespace project.BL.Facades;

public class SubjectFacade(IUnitOfWorkFactory unitOfWorkFactory, SubjectModelMapper subjectModelMapper) 
    : FacadeBase<SubjectEntity, SubjectListModel, SubjectModel, SubjectEntityMapper>(unitOfWorkFactory, subjectModelMapper), ISubjectFacade
{
    //public async Task SaveAsync(SubjectModel model)
    //{
    //    SubjectEntity entity = subjectModelMapper.MapToEntity(model);

    //    await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
    //    IRepository<SubjectEntity> repository =
    //        unitOfWork.GetRepository<SubjectEntity, SubjectEntityMapper>();

    //    if (await repository.ExistsAsync(entity))
    //    {
    //        await repository.UpdateAsync(entity);
    //        await unitOfWork.CommitAsync();
    //    }
    //}
}
