using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("SubjectId", "subjectId")]
public partial class TeacherClassificationSubjectDetailViewModel(IMessengerService messengerService) : TeacherNavigationSideBar(messengerService)
{
    public string? SubjectId { get; set; }
}

