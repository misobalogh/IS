using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

public partial class AdminNewStudentViewModel(IStudentFacade studentFacade, IMessengerService messengerService, UserDataService userDataService) : AdminNavigationSideBar(messengerService, userDataService)
{
    public StudentModel NewStudent { get; private set; } = StudentModel.Empty;

    [RelayCommand]
    async Task CreateStudent()
    {
        if (string.IsNullOrEmpty(NewStudent.Email) ||
            string.IsNullOrEmpty(NewStudent.FirstName) ||
            string.IsNullOrEmpty(NewStudent.LastName))
        {
            NotifyUser("Please fill in all required fields: First Name, Last Name, and Email.");
            return;
        }

        if (!NewStudent.Email.Contains('@'))
        {
            NotifyUser("Invalid email");
            return;
        }

        // Check if email is unique
        bool emailExists = await studentFacade.EmailExistsAsync(NewStudent.Email);
        if (emailExists)
        {
            NotifyUser("Email already exists.");
            return;
        }

        await studentFacade.SaveAsync(NewStudent);
        NotifyUser("New student successfully created");
        await Shell.Current.GoToAsync(nameof(AdminStudentsView));
    }

    private static void NotifyUser(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Shell.Current.DisplayAlert("Notification", message, "OK");
        });
    }
}
