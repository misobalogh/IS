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
    public async Task<List<SubjectListModel>> SearchSubject(string searchTerm)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        var repository = unitOfWork.GetRepository<SubjectEntity, SubjectEntityMapper>();

        IQueryable<SubjectEntity> query = repository.Get()
            .Where(entity => entity.Tag.ToLower().Contains(searchTerm.ToLower()) || entity.Name.ToLower().Contains(searchTerm.ToLower()));

        return query.AsEnumerable().Select(subjectModelMapper.MapToListModel).ToList();
    }
}
