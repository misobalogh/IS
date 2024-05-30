using project.BL.Mappers;
using project.BL.Models;
using project.DAL.Entities;
using project.DAL.Mappers;
using project.DAL.Repositories;
using project.DAL.UnitOfWork;

namespace project.BL.Facades;

public class EvaluationFacade(IUnitOfWorkFactory unitOfWorkFactory, EvaluationModelMapper evaluationModelMapper)
    : FacadeBase<EvaluationEntity, EvaluationListModel, EvaluationModel, EvaluationEntityMapper>(unitOfWorkFactory, evaluationModelMapper), IEvaluationFacade
{
    protected override List<string> IncludesNavigationPathDetail =>
        [$"{nameof(EvaluationEntity.Student)}", $"{nameof(EvaluationEntity.Activity)}"];

    public async Task SaveAsync(EvaluationModel model)
    {
        EvaluationEntity entity = evaluationModelMapper.MapToEntity(model);

        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        IRepository<EvaluationEntity> repository =
            unitOfWork.GetRepository<EvaluationEntity, EvaluationEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }
        else
        {
            await repository.InsertAsync(entity);
            await unitOfWork.CommitAsync();
        }
    }
}
