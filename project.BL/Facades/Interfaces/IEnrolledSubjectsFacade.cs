using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades;

public interface IEnrolledSubjectsFacade : IFacade<EnrolledSubjectEntity, EnrolledSubjectsListModel, EnrolledSubjectsModel>
{
    Task SaveAsync(EnrolledSubjectsModel model, Guid studentId);
    Task<List<EnrolledSubjectsListModel>> SearchSubject(string searchTerm);
    public IEnumerable<EnrolledSubjectsListModel> Sort(IEnumerable<EnrolledSubjectsListModel> subjects, string sortBy, bool descending);
}
