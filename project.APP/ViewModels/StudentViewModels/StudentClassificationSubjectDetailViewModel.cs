using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("SubjectId", "subjectId")]
public partial class StudentClassificationSubjectDetailViewModel(
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    IActivityFacade activityFacade,
    IMessengerService messengerService) : StudentNavigationSideBar(messengerService)
{
    public string? SubjectId { get; set; }

    public EnrolledSubjectsModel? EnrolledSubject { get; private set; }
    public IEnumerable<ActivityListModel> Activities { get; private set; } = null!;

    protected override async Task LoadDataAsync()
    {
        if (SubjectId == null)
        {
            return;
        }
        await base.LoadDataAsync();
        EnrolledSubject = await enrolledSubjectsFacade.GetAsync(Guid.Parse(SubjectId));
        Activities = await activityFacade.GetAsync();
    }
}

