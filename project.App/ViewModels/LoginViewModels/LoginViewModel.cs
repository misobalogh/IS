using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.App.Services;
using project.BL.Models;
using project.App.Views.TeacherViews;
using project.BL.Facades;

namespace project.App.ViewModels;

public partial class LoginViewModel(
    IStudentFacade studentFacade, 
    ITeacherFacade teacherFacade, 
    IMessengerService messengerService,
    StudentDataService studentDataService) : ViewModelBase(messengerService)
{
    public string? LoginCredential { get; set; }
    public string? PlaceholderText { get; set; } = "Enter your email";
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
        //await Shell.Current.GoToAsync(nameof(StudentScheduleView));
        //return;
        if (string.IsNullOrEmpty(LoginCredential))
        {
            // Notify user
            PlaceholderText = "Please enter your email";
            EntryBorderColor = Colors.Red;
            return;
        }

        StudentListModel? foundStudent = Students.FirstOrDefault(student => student.Email == LoginCredential);
        if (foundStudent != null)
        {
            LoggedStudent = await studentFacade.GetAsync(foundStudent.Id);
            if (LoggedStudent == null) {
                return;
            }
            studentDataService.SetCurrentUser(LoggedStudent);
            await Shell.Current.GoToAsync(nameof(StudentScheduleView));
        }

        TeacherListModel? foundTeacher = Teachers.FirstOrDefault(teacher => teacher.Email == LoginCredential);
        if (foundTeacher != null)
        {
            LoggedTeacher = await teacherFacade.GetAsync(foundTeacher.Id);
            await Shell.Current.GoToAsync(nameof(TeacherScheduleView));
        }

        // Notify user
        PlaceholderText = "Wrong email";
        EntryBorderColor = Colors.Red;
    }

    [RelayCommand]
    async Task LoginTeacher()
    {
        await Shell.Current.GoToAsync(nameof(TeacherScheduleView));
        return;
    }
}

