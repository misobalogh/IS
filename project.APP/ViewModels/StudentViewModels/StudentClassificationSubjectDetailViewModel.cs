using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("SubjectId", "subjectId")]
public partial class StudentClassificationSubjectDetailViewModel(IMessengerService messengerService) : StudentNavigationSideBar(messengerService)
{
    public string? SubjectId { get; set; }
}

