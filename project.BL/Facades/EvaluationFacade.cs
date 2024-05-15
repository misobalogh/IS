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

}
