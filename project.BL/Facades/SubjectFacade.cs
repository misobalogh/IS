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

}
