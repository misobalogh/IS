using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("StudentId", "studentId")]
public partial class AdminNewStudentViewModel(IStudentFacade studentFacade, IMessengerService messengerService, UserDataService userDataService) : AdminNavigationSideBar(messengerService, userDataService)
{
    public string? StudentId { get; set; }
    public StudentModel NewStudent { get; private set; } = StudentModel.Empty;

    protected override async Task LoadDataAsync()
    {
        if (string.IsNullOrEmpty(StudentId))
        {
            return;
        }

        await base.LoadDataAsync();
        NewStudent = await studentFacade.GetAsync(Guid.Parse(StudentId)) ?? StudentModel.Empty;
    }


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

    [RelayCommand]
    async Task DeleteStudent()
    {
        if (string.IsNullOrEmpty(StudentId))
        {
            NotifyUser("Student not found");
            return;
        }

        await studentFacade.DeleteAsync(Guid.Parse(StudentId));
        NotifyUser("Student successfully deleted");
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
