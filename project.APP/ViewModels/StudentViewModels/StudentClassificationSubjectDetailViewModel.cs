using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels.StudentViewModels;

[QueryProperty("SubjectId", "subjectId")]
public partial class StudentClassificationSubjectDetailViewModel : ViewModelBase
{
    public string SubjectId { get; set; }

    //private EnrolledSubjectsModel GetSubjectById(Guid id)
    //{
    //    return new EnrolledSubjectsModel
    //    {
    //        SubjectId = id,
    //        SubjectName = "Test test",
    //        Points = 50,
    //        Mark = Mark.A,
    //        Year = DateTime.Now
    //    };
    //}
}

