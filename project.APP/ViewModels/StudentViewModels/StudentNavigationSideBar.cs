using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.App.Services;
using project.App.Views.LoginViews;
using project.BL.Models;
using project.BL.Facades;

namespace project.App.ViewModels;

public partial class StudentNavigationSideBar(IMessengerService messengerService, StudentDataService studentDataService) : ViewModelBase(messengerService)
{
    public StudentModel? loggedUser { get; set; }
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        loggedUser = studentDataService.CurrentStudent;
    }

    [RelayCommand]
    async Task GoToStudentProfile()
    {
        await Shell.Current.GoToAsync(nameof(StudentProfileView));
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

    [RelayCommand]
    async Task Logout()
    {

        if (Application.Current?.MainPage?.Navigation != null)
        {
            studentDataService.ClearCurrentUser();
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

    }
}

