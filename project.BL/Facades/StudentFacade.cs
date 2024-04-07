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
    // public async Task SaveAsync(StudentModel model, Guid studentId)
    // {
    //     StudentEntity entity = studentModelMapper.MapToEntity(model);
    //
    //     await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
    //     IRepository<StudentEntity> repository =
    //         unitOfWork.GetRepository<StudentEntity, StudentEntityMapper>();
    //
    //     if (await repository.ExistsAsync(entity))
    //     {
    //         await repository.UpdateAsync(entity);
    //         await unitOfWork.CommitAsync();
    //     }
    // }
}
