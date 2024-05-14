using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.App.Services;

namespace project.App.ViewModels;

public partial class StudentNavigationSideBar(IMessengerService messengerService) : ViewModelBase(messengerService)
{
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
}

