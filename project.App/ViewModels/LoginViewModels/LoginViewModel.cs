using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.App.Views.AdminViews;
using project.App.Services;
using project.BL.Models;
using project.BL.Facades;

namespace project.App.ViewModels;

public partial class LoginViewModel(
    IStudentFacade studentFacade, 
    ITeacherFacade teacherFacade, 
    IMessengerService messengerService,
    UserDataService userDataService) : ViewModelBase(messengerService)
{
    public string? LoginCredential { get; set; }
    public string? PlaceholderText { get; set; } = "Enter your email";
    public string? WarningText { get; set; } = string.Empty;
    public Color EntryBorderColor { get; set; } = Colors.Transparent;
    public IEnumerable<StudentListModel> Students { get; private set; } = null!;
    public IEnumerable<TeacherListModel> Teachers { get; private set; } = null!;
    public StudentModel? LoggedStudent { get; private set; }
    public TeacherModel? LoggedTeacher { get; private set; }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Students = await studentFacade.GetAsync();
        Teachers = await teacherFacade.GetAsync();
    }

    [RelayCommand]
    async Task Login()
    {
        const string EmptyEntryPlaceholder = "Please enter your email";

        if (string.IsNullOrEmpty(LoginCredential))
        {
            // Notify user
            PlaceholderText = EmptyEntryPlaceholder;
            EntryBorderColor = Colors.Red;
            LoginCredential = string.Empty;
            return;
        }

        StudentListModel? foundStudent = Students.FirstOrDefault(student => student.Email == LoginCredential);
        if (foundStudent != null)
        {
            LoggedStudent = await studentFacade.GetAsync(foundStudent.Id);
            if (LoggedStudent == null) {
                return;
            }
            userDataService.SetCurrentUser(LoggedStudent);
            await Shell.Current.GoToAsync(nameof(StudentScheduleView));
            PlaceholderText = EmptyEntryPlaceholder;
            LoginCredential = string.Empty;
            EntryBorderColor = Colors.Transparent;
            return;
        }

        TeacherListModel? foundTeacher = Teachers.FirstOrDefault(teacher => teacher.Email == LoginCredential);
        if (foundTeacher != null)
        {
            LoggedTeacher = await teacherFacade.GetAsync(foundTeacher.Id);
            if (LoggedTeacher == null)
            {
                return;
            }
            userDataService.SetCurrentUser(LoggedTeacher);
            await Shell.Current.GoToAsync(nameof(TeacherScheduleView));
            PlaceholderText = EmptyEntryPlaceholder;
            LoginCredential = string.Empty;
            EntryBorderColor = Colors.Transparent;
            return;
        }

        if (string.Equals(LoginCredential, "admin@admin")) {
            userDataService.SetCurrentUser("admin");
            await Shell.Current.GoToAsync(nameof(AdminTeachersView));
            PlaceholderText = EmptyEntryPlaceholder;
            LoginCredential = string.Empty;
            EntryBorderColor = Colors.Transparent;
            return;
        }

        // Notify user
        PlaceholderText = "Wrong email";
        LoginCredential = string.Empty;
        EntryBorderColor = Colors.Red;
    }
}

