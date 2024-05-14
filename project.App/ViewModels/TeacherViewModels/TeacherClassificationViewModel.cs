using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.App.Services;
using project.BL.Facades;
using project.BL.Models;
using CommunityToolkit.Mvvm.Messaging;
using project.App.Views.TeacherViews;

namespace project.App.ViewModels;

public partial class TeacherClassificationViewModel(
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    IMessengerService messengerService) : TeacherNavigationSideBar(messengerService)
{
    public EnrolledSubjectsModel? EnrolledSubjects { get; 
        private set; }
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        EnrolledSubjects = await enrolledSubjectsFacade.GetAsync(Guid.Parse("371a5d4a-c60d-4e45-b3a1-db2bca96b24e"));
    }

    [RelayCommand]
    async Task ShowSubjectDetails(EnrolledSubjectsModel subject)
    {
        if (subject == null) return;
        var route = $"{nameof(StudentClassificationSubjectDetailView)}?subjectId={subject.SubjectId}";
        await Shell.Current.GoToAsync(route);
    }
}

