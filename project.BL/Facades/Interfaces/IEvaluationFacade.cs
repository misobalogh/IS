using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades;

public interface IEvaluationFacade : IFacade<EvaluationEntity, EvaluationListModel, EvaluationModel>
{
    Task SaveAsync(EvaluationModel evaluation);
}
