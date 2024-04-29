using project.BL.Mappers;
using project.BL.Models;
using project.DAL.Entities;
using project.BL.Models;
using project.BL.Mappers;
using project.DAL.Mappers;
using project.DAL.Repositories;
using project.DAL.UnitOfWork;

namespace project.BL.Facades;

public class StudentFacade(IUnitOfWorkFactory unitOfWorkFactory, StudentModelMapper studentModelMapper) 
    : FacadeBase<StudentEntity, StudentListModel, StudentModel, StudentEntityMapper>(unitOfWorkFactory, studentModelMapper), IStudentFacade
{
    public async Task<List<StudentListModel>> SearchStudent(string searchTerm)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        var repository = unitOfWork.GetRepository<StudentEntity, StudentEntityMapper>();

        IQueryable<StudentEntity> query = repository.Get()
            .Where(entity => entity.FirstName.ToLower().Contains(searchTerm.ToLower()) || entity.LastName.ToLower().Contains(searchTerm.ToLower()));
        //TODO: bude lepší startWith(searchTerm) nebo toto?

        return query.AsEnumerable().Select(studentModelMapper.MapToListModel).ToList();
    }
}
