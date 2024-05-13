using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.App.Services;
using project.BL.Models;
using project.App.Views.TeacherViews;

namespace project.App.ViewModels;

public partial class LoginViewModel(IMessengerService messengerService) : ViewModelBase(messengerService)
{
    public StudentModel model { get; set; } = StudentModel.Empty;
    public string? LoginCredential { get; set; }

    [RelayCommand]
    async Task login()
    {
        await Shell.Current.GoToAsync(nameof(StudentScheduleView));
    }

    [RelayCommand]
    async Task teacherLogin()
    {
        await Shell.Current.GoToAsync(nameof(TeacherScheduleView));
    }
}

