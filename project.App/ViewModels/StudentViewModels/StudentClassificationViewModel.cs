using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.App.Services;
using project.BL.Facades;
using project.BL.Models;
using CommunityToolkit.Mvvm.Messaging;

namespace project.App.ViewModels;

public partial class StudentClassificationViewModel(
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    IMessengerService messengerService) : ViewModelBase(messengerService)
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

    [RelayCommand]
    async Task GoToSchedule()
    {
        await Shell.Current.GoToAsync(nameof(StudentScheduleView));
    }
    [RelayCommand]
    async Task GoToClassification()
    {
        await Shell.Current.GoToAsync(nameof(StudentClassificationView));
    }
    [RelayCommand]
    async Task GoToSubjects()
    {
        await Shell.Current.GoToAsync(nameof(StudentSubjectsView));
    }
    [RelayCommand]
    async Task GoToTests()
    {
        await Shell.Current.GoToAsync(nameof(StudentTestsView));
    }
    [RelayCommand]
    async Task GoToRegistration()
    {
        await Shell.Current.GoToAsync(nameof(StudentRegistrationView));
    }
}

